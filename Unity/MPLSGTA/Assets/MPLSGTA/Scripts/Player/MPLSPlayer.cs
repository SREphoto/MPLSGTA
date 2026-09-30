using System.Collections.Generic;
using UnityEngine;

namespace MPLSGTA
{
    // Greybox third-person player for the IDS slice.
    // Controls: WASD move, Shift sprint, mouse look, Space jump, E vault, F soft-steal, R respawn.
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(WantedSystem))]
    public class MPLSPlayer : MonoBehaviour
    {
        [Header("Move")]
        public float walkSpeed = 4.5f;
        public float sprintSpeed = 7.5f;
        [Tooltip("Acceleration and braking at grip 1.0 (street). Lower grip scales this down, so stops take longer.")]
        public float baseTraction = 30f;
        public float jumpHeight = 0.9f;
        public float gravity = -20f;
        public float mouseSensitivity = 3f;

        [Header("Health")]
        public float maxHealth = 100f;
        public Transform spawnPoint;

        [Header("Camera")]
        public Transform cameraPivot;

        public float Health { get; private set; }
        public float Grip => grips.Count > 0 ? grips[grips.Count - 1].gripMultiplier : 1f;
        public string GripName => grips.Count > 0 ? grips[grips.Count - 1].surface.ToString() : "None";
        public string LastEvent { get; private set; } = "";

        [HideInInspector] public VaultZone currentVault;

        CharacterController cc;
        WantedSystem wanted;
        readonly List<GripZone> grips = new List<GripZone>();
        Vector3 planarVelocity;
        float verticalVelocity;
        float pitch;
        bool wasGrounded = true;
        float fallStartY;
        bool vaultSuccessPending;
        bool vaultFailPending;

        void Awake()
        {
            cc = GetComponent<CharacterController>();
            wanted = GetComponent<WantedSystem>();
            Health = maxHealth;
        }

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void EnterGrip(GripZone z) { if (!grips.Contains(z)) grips.Add(z); }
        public void ExitGrip(GripZone z) { grips.Remove(z); }

        void Update()
        {
            Look();
            Move();
            if (Input.GetKeyDown(KeyCode.E)) TryVault();
            if (Input.GetKeyDown(KeyCode.F)) { wanted.CommitSoftTheft(); LastEvent = "Soft steal"; }
            if (Input.GetKeyDown(KeyCode.R)) Respawn("Manual respawn");
            if (Input.GetKeyDown(KeyCode.Escape)) { Cursor.lockState = CursorLockMode.None; Cursor.visible = true; }
        }

        void Look()
        {
            float mx = Input.GetAxis("Mouse X") * mouseSensitivity;
            float my = Input.GetAxis("Mouse Y") * mouseSensitivity;
            transform.Rotate(0f, mx, 0f);
            pitch = Mathf.Clamp(pitch - my, -60f, 70f);
            if (cameraPivot != null) cameraPivot.localRotation = Quaternion.Euler(pitch, 0f, 0f);
        }

        void Move()
        {
            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            input = Vector3.ClampMagnitude(input, 1f);
            float speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;
            Vector3 target = transform.TransformDirection(input) * speed;

            // Grip sets how fast you can change velocity. Polished atrium (0.55) slides, street (1.0) plants.
            float traction = baseTraction * (cc.isGrounded ? Grip : 0.1f);
            planarVelocity = Vector3.MoveTowards(planarVelocity, target, traction * Time.deltaTime);

            if (cc.isGrounded)
            {
                if (verticalVelocity < 0f) verticalVelocity = -2f;
                if (Input.GetKeyDown(KeyCode.Space)) verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
            verticalVelocity += gravity * Time.deltaTime;

            cc.Move((planarVelocity + Vector3.up * verticalVelocity) * Time.deltaTime);

            bool grounded = cc.isGrounded;
            if (wasGrounded && !grounded) fallStartY = transform.position.y;
            if (!wasGrounded && grounded) Land(fallStartY - transform.position.y);
            wasGrounded = grounded;
        }

        void TryVault()
        {
            if (currentVault == null) return;
            Vector3 dir = currentVault.overRailDirection.normalized;
            if (Vector3.Dot(transform.forward, dir) < 0.5f) { LastEvent = "Face the rail to vault"; return; }

            bool clean = planarVelocity.magnitude >= sprintSpeed * currentVault.successSpeedFraction;
            // Hop over the rail. Rail height from the sheet, plus a little clearance.
            Vector3 p = transform.position + dir * 1.2f + Vector3.up * IdsNumbers.M(currentVault.railHeightCm) * 0.5f;
            cc.enabled = false;
            transform.position = p;
            cc.enabled = true;
            wasGrounded = false;
            fallStartY = p.y;
            if (clean)
            {
                vaultSuccessPending = true;
                planarVelocity = dir * 1.5f;   // controlled hang-drop, lands close to the wall
                verticalVelocity = 0f;
                LastEvent = "Vault success";
            }
            else
            {
                vaultFailPending = true;
                planarVelocity = dir * 3f;     // tumble
                verticalVelocity = 1f;
                LastEvent = "Vault fail";
            }
        }

        void Land(float dropMeters)
        {
            float fallLimit = IdsNumbers.M(IdsNumbers.FallDropCm) * 0.9f;
            if (vaultSuccessPending)
            {
                LastEvent = "Vault landed clean";
            }
            else if (vaultFailPending || dropMeters >= fallLimit)
            {
                float dmg = currentVault != null ? currentVault.failDamage : IdsNumbers.FailDamage;
                TakeDamage(dmg, vaultFailPending ? "Vault fail fall" : "Hard fall");
            }
            vaultSuccessPending = false;
            vaultFailPending = false;
        }

        public void TakeDamage(float amount, string reason)
        {
            Health -= amount;
            LastEvent = reason + " (-" + amount + ")";
            if (Health <= 0f) Respawn(reason + ", down");
        }

        public void Respawn(string reason)
        {
            cc.enabled = false;
            if (spawnPoint != null) transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
            cc.enabled = true;
            planarVelocity = Vector3.zero;
            verticalVelocity = 0f;
            Health = maxHealth;
            wanted.Clear();
            grips.Clear();
            LastEvent = reason;
        }
    }
}

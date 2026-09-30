using UnityEngine;

namespace MPLSGTA
{
    // Placed on the skyway rail edge. Press Vault (E) inside it while facing the rail.
    // Success: running hop over the 100 cm rail, controlled hang-drop to the street.
    // Fail: too slow, the player tumbles the full 503 cm and takes 100 damage. No soft float.
    [RequireComponent(typeof(BoxCollider))]
    public class VaultZone : MonoBehaviour
    {
        public float railHeightCm = IdsNumbers.RailHeightCm;
        public float fallDropCm = IdsNumbers.FallDropCm;
        public float failDamage = IdsNumbers.FailDamage;
        [Tooltip("Fraction of sprint speed needed for a clean vault.")]
        [Range(0f, 1f)] public float successSpeedFraction = 0.8f;
        [Tooltip("World direction that points over the rail.")]
        public Vector3 overRailDirection = Vector3.right;

        void Reset() { GetComponent<BoxCollider>().isTrigger = true; }

        void OnTriggerEnter(Collider other)
        {
            var p = other.GetComponent<MPLSPlayer>();
            if (p != null) p.currentVault = this;
        }

        void OnTriggerExit(Collider other)
        {
            var p = other.GetComponent<MPLSPlayer>();
            if (p != null && p.currentVault == this) p.currentVault = null;
        }
    }
}

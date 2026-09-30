using UnityEngine;

namespace MPLSGTA
{
    public enum GripSurface { AtriumPolished, SkywayDeck, StreetAsphalt, Wet, Ice, Snow }

    // Trigger volume that sets the player's grip while they stand inside it.
    [RequireComponent(typeof(BoxCollider))]
    public class GripZone : MonoBehaviour
    {
        public GripSurface surface = GripSurface.StreetAsphalt;
        [Range(0.1f, 1.5f)] public float gripMultiplier = 1f;

        public static float DefaultFor(GripSurface s)
        {
            switch (s)
            {
                case GripSurface.AtriumPolished: return IdsNumbers.GripAtriumPolished;
                case GripSurface.SkywayDeck: return IdsNumbers.GripSkywayDeck;
                case GripSurface.Wet: return IdsNumbers.GripWet;
                case GripSurface.Ice: return IdsNumbers.GripIce;
                case GripSurface.Snow: return IdsNumbers.GripSnow;
                default: return IdsNumbers.GripStreetAsphalt;
            }
        }

        void Reset()
        {
            GetComponent<BoxCollider>().isTrigger = true;
            gripMultiplier = DefaultFor(surface);
        }

        void OnValidate() { gripMultiplier = Mathf.Clamp(gripMultiplier, 0.1f, 1.5f); }

        void OnTriggerEnter(Collider other)
        {
            var p = other.GetComponent<MPLSPlayer>();
            if (p != null) p.EnterGrip(this);
        }

        void OnTriggerExit(Collider other)
        {
            var p = other.GetComponent<MPLSPlayer>();
            if (p != null) p.ExitGrip(this);
        }
    }
}

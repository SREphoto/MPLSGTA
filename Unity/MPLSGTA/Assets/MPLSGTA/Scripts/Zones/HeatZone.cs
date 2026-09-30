using UnityEngine;

namespace MPLSGTA
{
    public enum HeatZoneType { SoftTheft, Skyway, Street }

    // SoftTheft = Crystal Court, Skyway = heat dump corridors, Street = Nicollet wanted.
    [RequireComponent(typeof(BoxCollider))]
    public class HeatZone : MonoBehaviour
    {
        public HeatZoneType zoneType = HeatZoneType.Street;

        void Reset() { GetComponent<BoxCollider>().isTrigger = true; }

        void OnTriggerEnter(Collider other)
        {
            var w = other.GetComponent<WantedSystem>();
            if (w != null) w.EnterZone(this);
        }

        void OnTriggerExit(Collider other)
        {
            var w = other.GetComponent<WantedSystem>();
            if (w != null) w.ExitZone(this);
        }
    }
}

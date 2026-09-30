using System.Collections.Generic;
using UnityEngine;

namespace MPLSGTA
{
    // Heat loop for the IDS slice:
    // Crystal Court: stealing adds soft heat (no stars yet).
    // Skyway: heat drains fast (heat dump, breaks line of sight).
    // Nicollet street: any heat you carry out turns into wanted stars and slowly climbs.
    public class WantedSystem : MonoBehaviour
    {
        public float softHeatPerTheft = 1f;
        public float maxHeat = 5f;
        public float skywayDrainPerSecond = 0.5f;
        public float courtDrainPerSecond = 0.05f;
        public float streetClimbPerSecond = 0.1f;

        public float Heat { get; private set; }
        public int Stars { get; private set; }
        public HeatZoneType? CurrentZone => zones.Count > 0 ? zones[zones.Count - 1].zoneType : (HeatZoneType?)null;

        readonly List<HeatZone> zones = new List<HeatZone>();

        public void EnterZone(HeatZone z) { if (!zones.Contains(z)) zones.Add(z); }
        public void ExitZone(HeatZone z) { zones.Remove(z); }

        public void CommitSoftTheft()
        {
            if (CurrentZone == HeatZoneType.SoftTheft)
                Heat = Mathf.Min(maxHeat, Heat + softHeatPerTheft);
        }

        public void Clear() { Heat = 0f; Stars = 0; }

        void Update()
        {
            float dt = Time.deltaTime;
            switch (CurrentZone)
            {
                case HeatZoneType.Skyway:
                    Heat = Mathf.Max(0f, Heat - skywayDrainPerSecond * dt);
                    if (Heat <= 0f) Stars = 0;
                    break;
                case HeatZoneType.SoftTheft:
                    Heat = Mathf.Max(0f, Heat - courtDrainPerSecond * dt);
                    break;
                case HeatZoneType.Street:
                    if (Heat > 0f) Heat = Mathf.Min(maxHeat, Heat + streetClimbPerSecond * dt);
                    Stars = Mathf.CeilToInt(Heat);
                    break;
            }
        }
    }
}

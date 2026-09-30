// Locked IDS slice numbers. Source of truth: Docs/Map, Docs/Physics, Docs/Kits sheets.
// Sheets are written in centimeters (from the Unreal era). Unity uses meters, so M() divides by 100.
// Axis mapping: sheet +X (toward Nicollet) = Unity +X, sheet Z (up) = Unity Y, sheet Y = Unity Z.
namespace MPLSGTA
{
    public static class IdsNumbers
    {
        public static float M(float cm) => cm / 100f;

        // Crystal Court atrium shell (W x D x H), floor at 0.
        public const float AtriumWidthCm = 4267f;
        public const float AtriumDepthCm = 4267f;
        public const float AtriumHeightCm = 3688f;

        // Skyway module, exterior box. Two modules in a row along +X.
        public const float SkywayLengthCm = 1219f;
        public const float SkywayWidthCm = 670f;
        public const float SkywayHeightCm = 366f;
        public const float SkywayClearWidthCm = 549f;
        public const float Skyway1StartXCm = 2134f;   // atrium +X face
        public const float Skyway2StartXCm = 3353f;
        public const float Skyway2EndXCm = 4572f;

        // Nicollet plaza slab, top surface at street level.
        public const float StreetZCm = -503f;
        public const float PlazaLengthCm = 1829f;
        public const float PlazaWidthCm = 1219f;
        public const float PlazaThicknessCm = 30f;
        public const float StreetApronLengthCm = 2438f;

        // Grip multipliers (foot and vehicles share these).
        public const float GripAtriumPolished = 0.55f;
        public const float GripSkywayDeck = 0.75f;
        public const float GripStreetAsphalt = 1.0f;
        public const float GripWet = 0.70f;
        public const float GripIce = 0.35f;
        public const float GripSnow = 0.45f;

        // Vault and fall.
        public const float RailHeightCm = 100f;
        public const float FallDropCm = 503f;
        public const float FailDamage = 100f;
    }
}

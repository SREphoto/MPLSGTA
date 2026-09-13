# L_IDS_Slice

Create this level in the Unreal Editor (Content Browser → Maps → New Level). Name it `L_IDS_Slice`.

Physics binds: `Docs/Physics/IDS_PHYSICS_NUMBERS.md`.

## Place these actors

1. **Greybox geometry** — atrium floor + 8-story shell, two skyway boxes (18 ft clear / ~22 ft exterior), Nicollet plaza slab.
2. `AGripZoneVolume` ×3 — surfaces: AtriumPolished (0.55), SkywayDeck (0.75), StreetAsphalt (1.0).
3. `AHeatZoneVolume` ×3 — SoftTheft (court), Skyway (corridors), Street (Nicollet).
4. `AVaultVolume` on skyway railing edge — RailHeightCm=100, FallDropCm=503, FailDamage=100.
5. Player start + confirm `AMPLSGameMode` / `AMPLSCharacter`.

Project Game Default Map is already pointed at `/Game/Maps/L_IDS_Slice` in `Config/DefaultEngine.ini`.

# L_IDS_Slice

Create this level in the Unreal Editor (Content Browser → Maps → New Level). Name it `L_IDS_Slice`.

Full dims: `Docs/Map/IDS_GREYBOX_DIM_SHEET.md`.

## Greybox geometry (cm)

Origin = Crystal Court atrium floor center. **+X toward Nicollet.** Street Z = **−503** so skyway deck (Z=0) clears street by 16.5 ft.

1. **Atrium shell** — box **4267 × 4267 × 3688** (W×D×H), center `(0, 0, 1844)` (floor at Z=0).
2. **Skyway1** — exterior box **1219 × 670 × 366**, place so interior clear is 549 cm wide on Y=0; deck floor Z=0; starts at atrium +X face (~x 2134 → 3353).
3. **Skyway2** — same size, continues +X (~x 3353 → 4572).
4. **Nicollet plaza** — slab **1829 × 1219 × 30**, center past Skyway2 end at **Z = −503**; optional 2438 cm street apron along +X.

## Place these actors

1. `AGripZoneVolume` ×3 — `AtriumPolished` (court floor), `SkywayDeck` (both corridors), `StreetAsphalt` (plaza/street).
2. `AHeatZoneVolume` ×3 — SoftTheft (court), Skyway (corridors), Street (Nicollet).
3. `AVaultVolume` on skyway railing edge — `RailHeightCm=100`, `FallDropCm=503`.
4. Player start in atrium + confirm `AMPLSGameMode` / `AMPLSCharacter`.

Project Game Default Map is already pointed at `/Game/Maps/L_IDS_Slice` in `Config/DefaultEngine.ini`.

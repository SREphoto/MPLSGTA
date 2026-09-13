# IDS Vertical Slice — Animation Sheet
Animation lock for UE5 AnimBP / Control Rig greybox (`L_IDS_Slice`)

Dims match Map: `Docs/Map/IDS_GREYBOX_DIM_SHEET.md` and Physics: `Docs/Physics/IDS_PHYSICS_NUMBERS.md`. Do not invent new scale.

## World frame (shared)
| Item | Value |
|------|-------|
| Origin | Crystal Court atrium floor center |
| Axis | **+X toward Nicollet** |
| Skyway clear width | **549 cm (18 ft)** |
| Rail height | **100 cm** (~3.25 ft) |
| Fall drop | **503 cm** (≥16.5 ft) — **no soft float** |

## Loco blends (bind to `AGripZoneVolume` surfaces)
Three reusable blends — same skeleton, grip-driven blend space. Stylized-realism (readable slips/plants), not mocap-everything.

| Blend | Grip surface | Plant / stride | Where (IDS NOW) |
|-------|--------------|----------------|-----------------|
| **AtriumStroll** | `AtriumPolished` 0.55 | Slightly floaty plant, shorter stop | Crystal Court floor |
| **SkywayShuffle** | `SkywayDeck` 0.75 | Narrower stride, railing-aware | Both corridor decks |
| **StreetWalkRun** | `StreetAsphalt` 1.0 | Full walk/run, hard plant | Nicollet plaza / street |

Winter slip / ice overlays stay hooked to Physics `Ice`/`Snow` multipliers but are **not** in the IDS greybox yet.

## Vault / fail (bind to `AVaultVolume` + Kits glass/rail)
| Clip | Trigger | Notes |
|------|---------|-------|
| `Vault_Success` | Rail clear at **100 cm** | Forward vault over skyway rail |
| `Vault_Fail_Fall` | Miss / shove past rail | Hard fall **503 cm** to street — readable fail pose, **no soft float** |
| `Land_Hard` | After fail | Matches FailDamage feel; no soft recover into run |

## Crystal Court overlays
| Clip | Use |
|------|-----|
| `SoftSteal_Idle` / crouch | Soft-theft zone casing — readable without new loco system |
| District loiter stubs | Phone-zombie / shopper idles for atrium density (optional greybox) |

## Root motion
- Cap lateral root motion to **549 cm** clear so corridor clips never clip glass.
- Vault root motion must clear **100 cm** rail height; fail montage roots downward (no hover).
- Indoor→street handoff: blend AtriumStroll → SkywayShuffle → StreetWalkRun as volumes fire — do not hard-cut.

## Vehicle enter/exit stubs (arcade-plus classes)
Timing placeholders only for IDS street stubs — same classes as Physics `EArcadeVehicleClass`.

| Class | Enter/exit note |
|-------|-----------------|
| Compact | Fast door / short step-in |
| Sedan | Default street timing |
| SUV | Higher step-up |
| Sport | Low seat; longer sit |

Full boat / paddle / raft sets are **parked** (see below).

## UE5 greybox plan
1. `ABP_MPLSCharacter` — locomotion blend space driven by grip surface enum / multiplier from `AGripZoneVolume`.
2. Montages: `Vault_Success`, `Vault_Fail_Fall`, `SoftSteal_Idle`.
3. Control Rig optional for rail-aware hand plants later; greybox can be AnimBP-only.
4. Bind after Map volumes + Kits glass/rail + Physics envelopes are in `L_IDS_Slice`.

## Feel proof for this slice
1. Atrium stroll reads floatier / stops shorter than street.
2. Skyway shuffle narrows stride and keeps clearance inside 18 ft clear.
3. Failed vault = hard fall 503 cm — same silhouette language as Physics fail.
4. Soft-steal idle reads in Crystal Court without a second loco library.

## Parked (after IDS) — Minnetonka / water / Excelsior
| Set | Clips / rules |
|-----|----------------|
| Bde Maka Ska | Kayak/canoe enter/exit + tip/recover — **no motor mounts** |
| Floating docks | **18 in (45.7 cm)** step-up (Fletcher’s, Maynard’s, mansion private docks) |
| Launches | Ramp plant/slide (Grays Bay / west-bay) — no restaurant-slip timing |
| No-wake | Forced deplane → slow putter; tall-hull scrape/stuck on Carson’s ~5'8" |
| Fletcher’s | Crowded approach + slip-claim + boat-side pickup bump reactions |
| Maynard’s | Scarce-slip miss → circle or beach-kiss plant |
| Mansion docks | Low-wake stealth board + cut-line steal |
| Raft (Cruiser’s Cove) | Stand/drink idles on linked hulls; steal = cut-line + shove-off + forced putter |
| Excelsior | Day boutique stroll; night teen cruise loiter (Licks / Dock Cinema / Pizza Hut) + bar fight overlays |
| Big Island | Tourist casing stroll vs VIP swagger; ferry 18 in board-in; coaster-scaffold vault/climb + hard fall |

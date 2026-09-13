# IDS Vertical Slice — Kit Greybox Checklist
3D Designer lock for UE5 modular kits (`L_IDS_Slice`)

Dims match Map: `Docs/Map/IDS_GREYBOX_DIM_SHEET.md`. Do not invent new scale.

## Art lock
- **Stylized-realism** (GTA-like reads), not photoreal
- Modular kits; chase silhouettes over PBR flex
- Greybox first → denser kits later without moving Physics/Animation envelopes

## World frame (shared with Map)
| Item | Value |
|------|-------|
| Origin | Crystal Court atrium floor center |
| Axis | **+X toward Nicollet** |
| Skyway deck Z | 0 |
| Street Z | **−503** (16.5 ft under deck) |

## Modules NOW (IDS slice)

### 1. Crystal Court atrium shell
| Item | Value |
|------|-------|
| Greybox floor | **4267 × 4267 cm** (140 × 140 ft) |
| Height | **3688 cm** (8 stories / ~121 ft canopy) |
| Center | `(0, 0, 1844)` — floor at Z=0 |
| Shape | Pentagonal IRL (8 entries); **box proxy OK** for greybox |
| Later dress | Glass canopy + concrete/steel bones; polished floor material tag `AtriumPolished` |

### 2. Skyway corridor module (×2)
| Item | Value |
|------|-------|
| Clear width | **549 cm** (18 ft) |
| Exterior W × H | **670 × 366 cm** (~22 × 12 ft) |
| Module length | **1219 cm** (40 ft) |
| Walkable H | **305 cm** (10 ft) |
| Deck over street | **≥503 cm** |
| Placement | Skyway1 x ≈ 2134→3353; Skyway2 x ≈ 3353→4572; clear centered on Y=0; deck floor Z=0 |

Reuse one modular piece twice — do not unique-mesh each corridor.

### 3. Glass + rail kit piece
| Item | Value |
|------|-------|
| Sidewalls | ~80% glass (silhouette-readable, LOS break for heat dump) |
| Rail height | **100 cm** (~3.25 ft) — vault success bind |
| Fall drop | **503 cm** — hard fail to street (no soft float) |
| Bind targets | Physics `AVaultVolume`; Animation vault/fail root motion |

### 4. Nicollet plaza asphalt exit
| Item | Value |
|------|-------|
| Plaza slab | **1829 × 1219 × 30 cm** |
| Plaza Z | **−503** (street) |
| Optional apron | ~**2438 cm** curb run along +X |
| Material tag | `StreetAsphalt` |

### 5. Sidewalk / street tile stubs
Cheap modular sidewalk edge + asphalt tiles for plaza exit into downtown — enough for on-foot → street handoff, not a full block kit.

## LOD / silhouette
| Pass | Goal |
|------|------|
| Greybox | Solid boxes + rail strip — prove grip/heat/vault |
| Kit v1 | Glass/rail readability, atrium canopy silhouette, plaza curb |
| Later | Nanite-friendly denser kits; keep same outer envelopes |

Chase reads beat PBR flex: skyway glass must break LOS; rail must read for vault; atrium canopy must read from Nicollet.

## Editor drop order
1. Atrium shell (Map box sizes)
2. Skyway1 + Skyway2 modules
3. Glass/rail piece on corridor edges
4. Nicollet plaza slab + sidewalk stubs
5. Hand off to Physics volumes + Animation root-motion binds

## Parked (after IDS) — kit targets only
- **Vehicles:** 3–4 arcade-plus chassis shells (enter/exit classes)
- **Water craft:** Bde Maka Ska paddle (kayak/canoe); Minnetonka planing/jetski (short vs tall hull flag for bridges)
- **Docks:** floating 18 in freeboard vs trailer-ramp; Fletcher’s dense slip field; Maynard’s scarce guest apron
- **Mansions:** shared estate bones (shingle/stone) + boathouse + one pagoda-roof landmark
- **Excelsior:** Water St facade run + Licks / Dock Cinema / Pizza Hut neon shells
- **Big Island:** ferry pier, Seville-style tower, coaster scaffold (parkour), VIP/casino shell
- **Channel props:** red/green buoys; Carson’s ~5'8" / Narrows ~18'3" bridge gates; raft-up cluster props
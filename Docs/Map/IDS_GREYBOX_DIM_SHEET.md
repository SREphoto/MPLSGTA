# IDS Vertical Slice — Greybox Dim Sheet
Map Expert lock for UE5 blockout (`L_IDS_Slice`)

## 3-node graph
1. **Crystal Court atrium** (hub) — soft-theft / polished grip
2. **Skyway corridor(s)** — heat dump / mid grip / LOS break
3. **Nicollet plaza exit** — street wanted / full asphalt grip

World origin: atrium floor center. **+X toward Nicollet.** Street asphalt Z is set so skyway deck sits **503 cm** above street.

## Crystal Court
| Item | Value |
|------|-------|
| Footprint | ~23,000 ft² atrium |
| Shape | pentagonal (8 entries); greybox = box proxy OK |
| Height | 8 stories / canopy ~121 ft (3688 cm) |
| Greybox floor | 4267 × 4267 cm (140 × 140 ft) |
| Floor Z | 0 (origin) |
| Center | (0, 0, 0) |
| Grip / heat | `AtriumPolished` / SoftTheft |

## Skyways (×2 modules)
| Item | Value |
|------|-------|
| Clear width | 549 cm (18 ft) |
| Exterior W × H | 670 × 366 cm (~22 × 12 ft) |
| Walkable H | 305 cm (10 ft) |
| Module length | 1219 cm (40 ft) |
| Deck over street | ≥503 cm (16.5 ft) |
| Rail height | 100 cm (~3.25 ft) |
| Grip / heat | `SkywayDeck` / Skyway heat dump |

**Placement (deck floor at Z = atrium floor Z = 0; street at Z = −503):**
- Skyway1 box center: (2133 + 610, 0, 183) ≈ atrium +X face outward — tune so corridor mouth meets atrium wall
- Skyway2 continues +X after Skyway1 by +1219 cm

Practical Editor placement (recommended):
- Skyway1: from atrium +X face at x ≈ 2134, extends to x ≈ 3353 (length 1219)
- Skyway2: x ≈ 3353 → 4572
- Interior clear width centered on Y=0

## Nicollet plaza
| Item | Value |
|------|-------|
| Plaza pad | 1829 × 1219 cm (60 × 40 ft) |
| Street apron | ~2438 cm (80 ft) curb run |
| Plaza center | past Skyway2 end, Z = −503 (street) |
| Grip / heat | `StreetAsphalt` / Street wanted |

## Volumes to place
| Actor | Where | Key props |
|-------|-------|-----------|
| `AGripZoneVolume` ×3 | atrium floor, skyway decks, plaza/street | AtriumPolished, SkywayDeck, StreetAsphalt |
| `AHeatZoneVolume` ×3 | court, corridors, Nicollet | SoftTheft, Skyway, Street |
| `AVaultVolume` | skyway railing edge | RailHeightCm=100, FallDropCm=503 |

## Out of scope this slice
Full skyway network, winter mats, boats, Minnetonka hubs — parked.

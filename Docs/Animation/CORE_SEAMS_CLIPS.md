# Playable Core — District Clip Targets
Animation · parallel to IDS Editor greybox (docs only)

Spatial seams: `Docs/Map/CORE_STREET_SEAMS.md`. Kit families: `Docs/Kits/CORE_DISTRICT_KIT_TARGETS.md`.
IDS loco stays first: `Docs/Animation/IDS_ANIMATION_SHEET.md`.

## Priority
1. **IDS AnimBP greybox** first (atrium / skyway / street + vault/fail)
2. This sheet = next district idle / choke overlays once IDS boxes prove the loop

## Shared loco (already locked)
Reuse IDS blends everywhere possible — densify with **idle variants**, not new walk cycles per district.

| Blend | Where it still applies |
|-------|------------------------|
| `StreetWalkRun` | North Loop, First Ave, Uptown streets |
| `AtriumStroll` / `SkywayShuffle` | Downtown indoor layer only |
| Vault / fail | Skyway exits + later coaster/scaffold (hubs parked) |

## District idle / overlay packs

### Downtown / IDS (in progress)
| Clip set | Notes |
|----------|-------|
| SoftSteal + atrium loiter | Already on IDS sheet |
| Nicollet exit pop | Blend skyway shuffle → street run on heat handoff |
| Office / retail phone-zombie | Cheap density on plaza |

### North Loop
| Clip set | Notes |
|----------|-------|
| Loading-dock idle | Worker lean / clipboard / smoke — warehouse casing cover |
| Truck-alley shuffle | Narrower street plant in alleys; still `StreetWalkRun` base |
| Rail-underpass crouch peek | LOS-break choke #2 — ambush read |
| Fence vault stub | Short yard fence (not skyway 100 cm rail) — separate short montage |

### First Ave / stadiums
| Clip set | Notes |
|----------|-------|
| Crowd loiter packs | Plaza density; slow shuffle through event heat |
| Barrier hop | Temporary road-closure props |
| Club-door bounce | Neon night queue idle (First Ave facade) |
| Parking-deck stair / ramp plant | Chase funnel verticality |

### Uptown
| Clip set | Notes |
|----------|-------|
| Hennepin cruise loiter | Slow sidewalk hang; bar-row night swap |
| Bar fight / pickup overlays | Same language as Excelsior strip (reuse later) |
| Side-street alley cut | Quick peek / sprint restart into cruise |

### Bde Maka Ska shore
| Clip set | Notes |
|----------|-------|
| Soft-beach plant | 0–1 ft grade into path — matches Physics soft beach |
| Kayak put-in / tip-recover | **Paddle only** — no motor mounts |
| Shore cut-off stumble | Cop path intercept read at choke #5 |

## Choke-point clip checklist
1. Skyway → Nicollet heat pop — IDS sheet
2. North Loop underpass peek / ambush
3. I-94 bridge / underpass sprint (few crossings — no new loco, just stamina-readable run)
4. Stadium plaza crowd push / barrier hop
5. Bde Maka Ska paddle escape + shore cut-off

## Shared rules
- Stylized-realism silhouette reads at chase speed
- District dress = idle variants on one loco skeleton
- Fence vault ≠ skyway vault (different height band)
- Minnetonka / MoA / MSP / St. Paul still parked

## Out of scope here
Full AnimBP authoring in Editor (Samuel / post-IDS greybox), mocap library, unique walk per NPC.

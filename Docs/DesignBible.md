# MPLSGTA Design Bible

Living locks for the Minneapolis / Minnetonka GTA-like project. **Engine: Unreal Engine 5. First build target: IDS vertical slice.**

## Art fidelity
- **Stylized-realism** (GTA-like reads), not photoreal
- Modular kits; chase silhouettes over PBR flex

## Map (Map Expert)
### Playable core vs hubs
| Continuous playable | Travel hubs (mission load / fast-travel) |
|---------------------|------------------------------------------|
| Downtown IDS/skyways → North Loop → First Ave / stadiums → Uptown / Bde Maka Ska | Mall of America, MSP, Minnetonka, St. Paul |

Hard edges on the core: **Mississippi** + **I-94**. Dense ~4–6 mi² slice, not sparse freeway grid.

### IDS vertical slice graph (NOW)
`Crystal Court atrium → 1–2 skyways → Nicollet plaza` — see `Docs/Map/IDS_GREYBOX_DIM_SHEET.md` for cm placements.

### Minnetonka hub (parked)
- **Story anchors:** Excelsior, Fletcher’s, Maynard’s, Big Island
- **Launches:** Grays Bay (trailer-in) + one west-bay ramp
- **Mansions:** 5 sparse estate nodes (private dock + boathouse)
- **Channels / no-wake:** buoy corridors; ≤5 mph near shore/docks; Carson’s ~5'8" tall-hull fail; Narrows ~18'3" clear
- **Excelsior:** Water Street night cruise (Licks, Dock Cinema, Pizza Hut corner) feeds ferry to Big Island
- **Party pipeline:** Fletcher’s Wharf staging → Cruiser’s Cove raft-up → island amusement reboot
- **Bde Maka Ska (in core):** paddle/sail only — soft beach put-ins, no motor docks

## IDS vertical slice (NOW)
3-node graph: **Crystal Court atrium → 1–2 skyways → Nicollet plaza exit**

| Item | Lock |
|------|------|
| Crystal Court | ~23,000 ft², 8 stories, glass canopy ~121 ft, pentagonal, 8 entries |
| Skyways | 18 ft clear (12 min), ~80% glass, ≥16.5 ft over street, exterior ~20–24 ft |
| Grip | Atrium polished low → skyway mid → Nicollet asphalt full |
| Heat | Soft-theft in court; skyway = heat dump (LOS break, slower chase); street wanted on Nicollet |
| Vault | Rail ~3–3.5 ft success; fail = hard fall ≥16.5 ft (no soft float) |
| Vehicles | Arcade-plus; 3–4 chassis classes; material grip multipliers |

## Water (parked until after IDS)
- **Bde Maka Ska:** paddle / sail only (no motors) — fragile heat dumps
- **Minnetonka hub:** motors / jetski; story anchors Excelsior, Fletcher’s, Maynard’s, Big Island
- Launches: Grays Bay + west-bay ramp; docks 18 in freeboard
- No-wake ≤5 mph near shore / channels; Water Patrol heat; bridge height gates
- Fletcher’s → Cruiser’s Cove raft-up party pipeline
- Big Island amusement reboot (1906–11 bones); Excelsior Water St night strip

## Kits (3D Designer)
Full checklist: `Docs/Kits/IDS_KIT_GREYBOX.md`. Dims match Map greybox sheet.

### IDS slice (NOW)
| Module | Greybox size (cm) |
|--------|-------------------|
| Crystal Court atrium shell | floor 4267×4267, H 3688; center (0,0,1844) |
| Skyway corridor ×2 | clear 549 W; exterior 670×366; len 1219; deck Z=0 |
| Glass + rail | ~80% glass; rail H 100; fall drop 503 |
| Nicollet plaza exit | slab 1829×1219×30 at Z=−503; apron ~2438 |
| Sidewalk/street stubs | plaza exit tiles only |

### Parked Minnetonka / water (after IDS)
Paddle vs planing/jetski chassis; 18 in float dock vs trailer ramp; Fletcher’s dense slips / Maynard’s apron; mansion estate+boathouse; Excelsior neon facades; Big Island pier/tower/coaster; raft cluster; buoy + bridge gates.

## Physics (Physics Expert)
Full numbers: `Docs/Physics/IDS_PHYSICS_NUMBERS.md`. Dims match Map greybox sheet.

### IDS slice (NOW)
| Lock | Value |
|------|-------|
| Grip | `AtriumPolished` 0.55 → `SkywayDeck` 0.75 → `StreetAsphalt` 1.0 (shared foot + vehicle) |
| Vault | `RailHeightCm=100`; fail `FallDropCm=503`; `FailDamage=100` — no soft float |
| Vehicles | Arcade-plus classes (Compact/Sedan/SUV/Sport); effective grip = BaseGrip × surface multiplier |

Wet / Ice / Snow multipliers are hooked in `EGripSurface` but not placed in the IDS greybox yet.

### Parked Minnetonka / water (after IDS)
- Bde Maka Ska paddle-only + tip; docks 18 in freeboard; launches = ramp
- No-wake ≤5 mph force-deplane; Carson’s ~5'8" tall-hull fail; Narrows ~18'3" clear
- Raft soft-snap + shove-off steal; Fletcher’s wide cone / Maynard’s scarce-slip magnet

## Animation (Animation)
Full sheet: `Docs/Animation/IDS_ANIMATION_SHEET.md`. Dims match Map / Physics.

### IDS slice (NOW)
| Lock | Value |
|------|-------|
| Loco | `AtriumStroll` → `SkywayShuffle` → `StreetWalkRun` (grip 0.55 / 0.75 / 1.0) |
| Vault | Success at rail **100 cm**; fail fall **503 cm** — no soft float |
| Overlays | Crystal Court `SoftSteal_Idle`; optional atrium loiter stubs |
| Root motion | Cap to **549 cm** skyway clear; vault clears 100 cm rail |
| Vehicles | Enter/exit stubs for Compact/Sedan/SUV/Sport (timing only) |

### Parked Minnetonka / water (after IDS)
- Bde Maka Ska paddle tip/recover (no motors); docks 18 in step; launches = ramp plant
- No-wake putter + Carson’s tall-hull scrape; Fletcher’s crowd / Maynard’s scarce-slip
- Raft steal shove-off; Excelsior day/night idles; Big Island tourist vs VIP + coaster vaults

## Research (Game Research & Asset Collector)
- **IDS ref pack:** `Docs/Research/IDS_REF_PACK.md` — Crystal Court dims, skyway widths, Nicollet exit, photo/page refs, grip tags, hand-off checklist
- Living rule: measurements before kits; hubs vs continuous playable called out early
- Next packs (parked): Minnetonka docks/launches/mansions, Excelsior Water St, Big Island 1906 park reboot, no-wake/channels

## Gameplay / Engine (Gameplay And Game Engine Expert)
- Wanted/heat: SoftTheft (court) → Skyway heat dump → Street wanted (Nicollet)
- Arcade-plus vehicles + grip multipliers bound to physics numbers above
- C++ stubs in `Source/MPLSGTA/` — defaults match Physics sheet (0.55 / 0.75 / 1.0, rail 100 / fall 503)


## Kits — core districts (parallel)
While IDS greybox is in Editor: warehouse / Uptown / stadium / shore kit families live in `Docs/Kits/CORE_DISTRICT_KIT_TARGETS.md`, keyed to Map `CORE_STREET_SEAMS.md`.

## Columns (owners)
| Column | Owner |
|--------|-------|
| Research | Game Research & Asset Collector |
| Map | Map Expert |
| Kits | 3D Designer |
| Physics | Physics Expert |
| Animation | Animation |
| Gameplay / Engine | Gameplay And Game Engine Expert |

## Repo
`https://github.com/SREphoto/MPLSGTA`
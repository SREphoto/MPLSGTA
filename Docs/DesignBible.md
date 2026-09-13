# MPLSGTA Design Bible

Living locks for the Minneapolis / Minnetonka GTA-like project. **Engine: Unreal Engine 5. First build target: IDS vertical slice.**

## Art fidelity
- **Stylized-realism** (GTA-like reads), not photoreal
- Modular kits; chase silhouettes over PBR flex

## Playable core vs hubs
| Continuous playable | Travel hubs (mission load / fast-travel) |
|---------------------|------------------------------------------|
| Downtown IDS/skyways → North Loop → First Ave / stadiums → Uptown / Bde Maka Ska | Mall of America, MSP, Minnetonka, St. Paul |

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

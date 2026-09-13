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

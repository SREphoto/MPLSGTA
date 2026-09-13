# IDS Vertical Slice — Physics Numbers Sheet
Physics Expert lock for UE5 Chaos / arcade-plus binds (`L_IDS_Slice`)

Dims match Map: `Docs/Map/IDS_GREYBOX_DIM_SHEET.md` (and Kits glass/rail). Do not invent new scale.

## World frame (shared with Map / Kits)
| Item | Value |
|------|-------|
| Origin | Crystal Court atrium floor center |
| Axis | **+X toward Nicollet** |
| Skyway deck Z | 0 |
| Street Z | **−503** (16.5 ft under deck) |

## Grip surfaces (`AGripZoneVolume` / `EGripSurface`)
Foot loco and arcade vehicles share the same multipliers so atrium → skyway → Nicollet changes stopping distance and foot plant together.

| Surface | GripMultiplier | Where (IDS NOW) |
|---------|----------------|-----------------|
| `AtriumPolished` | **0.55** | Crystal Court floor |
| `SkywayDeck` | **0.75** | Both corridor decks |
| `StreetAsphalt` | **1.0** | Nicollet plaza / street |
| `Wet` | **0.70** | Hook — not placed in IDS greybox yet |
| `Ice` | **0.35** | Hook — winter later |
| `Snow` | **0.45** | Hook — winter later |

Default `GripMultiplier` on the volume should match the surface row when you set `Surface` in the Editor (tunable, clamp 0.1–1.5).

## Vault / fall (`AVaultVolume`)
Bind to Kits glass + rail piece on skyway edge.

| Prop | Value | Feel |
|------|-------|------|
| `RailHeightCm` | **100** (~3.25 ft) | Vault success band (~3–3.5 ft) |
| `FallDropCm` | **503** (≥16.5 ft) | Hard fail to street — **no soft float** |
| `FailDamage` | **100** | Clear fail state |

## Arcade-plus vehicles (`AArcadeVehicle`)
Not sim tires. Effective grip = `BaseGrip × SurfaceGripMultiplier`.

| Class (`EArcadeVehicleClass`) | Role |
|-------------------------------|------|
| Compact | Tight downtown / skyway-adjacent streets |
| Sedan | Default street class |
| SUV | Heavier plant, same grip multipliers |
| Sport | Higher base speed; still uses surface multipliers |

IDS slice only needs street stubs + `StreetAsphalt` grip; winter mats and boat chassis stay parked.

## IDS volume placement checklist
| Actor | Where | Key props |
|-------|-------|-----------|
| `AGripZoneVolume` ×3 | atrium floor, skyway decks, plaza/street | `AtriumPolished` 0.55 / `SkywayDeck` 0.75 / `StreetAsphalt` 1.0 |
| `AVaultVolume` | skyway railing edge | `RailHeightCm=100`, `FallDropCm=503`, `FailDamage=100` |

Heat volumes stay Gameplay-owned (`AHeatZoneVolume`); Physics only owns contact / motion envelopes.

## Feel proof for this slice
1. Atrium stroll stops shorter / floatier than street (0.55 vs 1.0).
2. Skyway mid-grip (0.75) reads between court and Nicollet.
3. Failed vault off rail = hard fall 503 cm — readable fail, not soft clip.
4. Vehicle on Nicollet uses full asphalt; entering a wet/ice hook later multiplies the same stack.

## Parked (after IDS) — water / Minnetonka
| Lock | Number / rule |
|------|----------------|
| Bde Maka Ska | Paddle/sail only; high tip; soft beach **0–1 ft** grade into shore |
| Dock freeboard | **18 in (45.7 cm)** floating step-up (story anchors, mansion private docks) |
| Launches | Concrete ramp (Grays Bay / west-bay) — no step-up; soft planing takeoff |
| No-wake | **≤5 mph** → force deplane + soft wake kill; blow = Water Patrol heat |
| Carson’s bridge | **~5'8" (173 cm)** clearance — tall-hull scrape/stuck hard fail |
| Narrows bridge | **~18'3" (556 cm)** — clear for planing classes |
| Raft (Cruiser’s Cove) | Soft-snap cluster (springy boat-to-boat, not rigid); steal = cut-line + shove-off; forced putter until clear of cove band |
| Fletcher’s dock | Wide approach cone; NPC bump = soft heat |
| Maynard’s dock | Tight single-slip magnet; miss = circle or beach-kiss |

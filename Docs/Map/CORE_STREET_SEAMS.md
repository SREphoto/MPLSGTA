# Playable Core — Street Seam Block Diagram
Map Expert · post-IDS planning (docs only — IDS greybox stays first in Editor)

## Scope
Continuous playable ground only (not travel hubs):
**IDS / skyways → North Loop → First Ave / stadiums → Uptown / Bde Maka Ska**

Hard edges: **Mississippi River** (east spine) · **I-94** (south cut)

Target density: tight ~4–6 mi² — every block needs a hook, no empty freeway ribbons.

## District seams (N→S / river→lakes)

```
                    MISSISSIPPI
                         │
         ┌───────────────┼───────────────┐
         │   NORTHEAST   │  (future densify; arts / warehouses)
         └───────────────┼───────────────┘
                         │
    ┌────────────────────┴────────────────────┐
    │              NORTH LOOP                 │
    │  warehouses · loading alleys · yards    │
    │  seam S: railroad / Washington Ave      │
    └────────────────────┬────────────────────┘
                         │
    ┌────────────────────┴────────────────────┐
    │         DOWNTOWN / IDS SLICE            │
    │  Crystal Court → skyways → Nicollet     │
    │  vertical indoor layer = heat dump      │
    │  seam W: toward stadiums / First Ave    │
    │  seam S: toward I-94 cut                │
    └──────────┬─────────────────┬────────────┘
               │                 │
    ┌──────────┴──────┐   ┌──────┴────────────┐
    │ FIRST AVE /     │   │  (skyway stub     │
    │ STADIUMS        │   │   network only    │
    │ concert / sport │   │   in downtown)    │
    │ heat nodes      │   └───────────────────┘
    └──────────┬──────┘
               │ cross I-94 via few choke bridges / underpasses
    ┌──────────┴──────────────────────────────┐
    │              UPTOWN                     │
    │  nightlife · Hennepin strip · lakeside  │
    │  seam E: Bde Maka Ska shore (paddle)    │
    └──────────┬──────────────────────────────┘
               │
         BDE MAKA SKA (paddle/sail only)
```

## Block roles (kit targets for 3D)

| District | Block flavor | Street toys | Indoor / special |
|----------|--------------|-------------|------------------|
| Downtown IDS | glass office / retail / skyway lids | Nicollet pedestrian + one-ways | Crystal Court, skyway corridors |
| North Loop | brick warehouse, loading docks | wide truck alleys, rail spurs | loft interiors later |
| First Ave / stadiums | venue massing, parking decks | event traffic, chase funnels | First Ave club, stadium plazas |
| Uptown | mixed retail / apartments | Hennepin cruise, side streets | bar row, lake access |
| Bde Maka Ska shore | parks / paths | soft beach put-ins | kayak racks only (no motor docks) |

## Choke points (wanted / chase)
1. Skyway exits onto Nicollet (indoor→street heat pop) — already in IDS slice
2. North Loop rail underpasses (LOS breaks, ambush alleys)
3. I-94 bridge / underpass few crossings (south gate to Uptown)
4. Stadium plaza gates (crowd density, temporary road closures)
5. Bde Maka Ska shore (paddle escape; cops cut off on path)

## What this is NOT
- Not MoA / MSP / Minnetonka / St. Paul (travel hubs)
- Not full Twin Cities continuous drive
- Not replacing IDS Editor greybox — that stays Samuel’s next click in UE5

## Next map drops (after IDS boxes exist)
1. Downtown skyway stub graph (which buildings connect in slice+)
2. North Loop alley module spacing (warehouse kit repeat distance)
3. I-94 crossing count lock (how many playable bridges)

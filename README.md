# MPLSGTA

GTA-like open-world fantasy set in Minneapolis / Minnetonka. **Engine: Unreal Engine 5.4+.**

## What this repo proves first (IDS vertical slice)

Greybox + systems for **Crystal Court → skyway corridors → Nicollet plaza**:

| System | Target |
|--------|--------|
| Wanted / heat | Street heat on Nicollet; skyway = LOS break / slower chase; Crystal Court = soft-theft zone |
| Grip zones | Atrium (low) → skyway (mid) → street asphalt (full) |
| Vault / fall | ~3–3.5 ft rail success; fail = hard fall from ≥16.5 ft (no soft float) |
| Vehicles | Arcade-plus chassis stubs + material grip multipliers |

Art fidelity: **stylized-realism** (not photoreal). Full Twin Cities map and Minnetonka water hub are design-locked but **out of scope** for this first scaffold.

## Open in Unreal

1. Install **UE 5.4+** (Epic Games Launcher).
2. Right-click `MPLSGTA.uproject` → **Generate Visual Studio project files** (Windows) or open directly on Mac.
3. Open `MPLSGTA.uproject`. First launch will compile the `MPLSGTA` C++ module.
4. Create map **Content/Maps/L_IDS_Slice** (see below) and set it as Game Default Map in Project Settings.

### Create `L_IDS_Slice` (one-time in editor)

Add four trigger volumes (or boxes) named:

- `CrystalCourt` — large atrium floor (polished / low grip + soft-theft heat)
- `Skyway_A`, `Skyway_B` — 18 ft clear corridors (mid grip + heat dump)
- `NicolletExit` — street plaza (full asphalt grip + street wanted)

Place `AMPLSCharacter` (or a Blueprint child) as the default pawn. Attach `UWantedComponent`. Overlap the zone volumes with `AGripZoneVolume` / `AHeatZoneVolume` actors from this module.

Dims reference: Crystal Court ~23k ft² / ~8 stories / ~121 ft canopy; skyways 18 ft clear, ~20–24 ft exterior, ≥16.5 ft over street.

## Repo layout

```
Config/           Engine / game defaults
Content/Maps/     Level notes (create L_IDS_Slice in editor)
Docs/             Design bible
Source/MPLSGTA/   C++ gameplay modules
```

## Design bible

See [Docs/DesignBible.md](Docs/DesignBible.md) for locked map / kits / physics / animation / gameplay / research columns.

## Note on Cloud Agents

Scaffold was pushed via GitHub CLI from the gameplay agent (Cloud Agents unavailable on current plan). Future C++ work can continue the same way or via Pro Cloud Agents.

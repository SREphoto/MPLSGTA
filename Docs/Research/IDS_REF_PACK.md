# IDS Vertical Slice — Research Ref Pack

**Repo:** `SREphoto/MPLSGTA`  
**Owner:** Game Research & Asset Collector  
**Target level:** `L_IDS_Slice` (Crystal Court → skyway → Nicollet)

Use these locks for greybox kits, collision, and loco. Photo URLs are public reference sources (not redistributed assets).

---

## 1. Crystal Court (IDS Center)

| Fact | Value | Source notes |
|------|-------|--------------|
| Floor area | ~23,000 ft² (~2,137 m²) | IDS Center / Crystal Court marketing |
| Height / stories | 8-story atrium; glass canopy ~121 ft (~36.9 m) | Historic descriptions; fountain cascade ~105 ft cited historically |
| Plan | Roughly pentagonal; **8 entry points** | Philip Johnson / Burgee; kaleidoscopic roof of clear cubes |
| Material read | Glass skylight canopy + concrete/steel structure; polished atrium floor | Stylized-realism: ice sheen optional later, not photoreal PBR |
| Role in slice | Soft-theft / casing hub; low-grip polished zone | Gameplay lock |

### Kit / greybox targets
- Pentagon atrium shell, ~8-story volume, open center (trees / seating as props later)
- Perimeter retail/office walls with 8 portal cuts (skyway + street connections)
- Floor material tag: `Grip_Atrium` (polished)

### Photo / page refs
- https://ids-center.com/crystal-court-ids-center/
- https://ids-center.com/the-ids-center/
- https://ids-center.com/iconic-crystal-court-in-minnesotas-tallest-building-faces-renovation-years-in-the-works/

---

## 2. Skyways (downtown core)

| Fact | Value | Source notes |
|------|-------|--------------|
| Clear width (target) | **18 ft** between handrails (core encouraged) | Minneapolis zoning / skyway standards |
| Clear width (min) | 12 ft between handrails | Same |
| Exterior width | Cap ~30 ft; slice modules **20–24 ft** exterior | Matches locked kits column |
| Sidewalls | ≥80% glazing, clear/light tint | Bird-safe patterns exist IRL — optional prop detail |
| Deck over street | ≥**16.5 ft** clearance | Star Tribune / city figures |
| Rail height (game) | ~3–3.5 ft (~100 cm) vault success | Physics / Animation lock |
| Fall fail | Hard fall from deck to street (≥16.5 ft) | No soft float |

### Kit / greybox targets
- Corridor module: **18 ft clear** walkable, glass + rail piece
- Length units per Map dim sheet (see PR map/ids-greybox-layout)
- Material tag: `Grip_Skyway` (mid)
- Heat: LOS break / slower chase (gameplay) — research supports narrow glass tube reads

### Photo / page refs
- LMCD / city skyway width standards (ordinance summaries)
- https://www.startribune.com/minneapolis-skyways-by-the-numbers/366130481
- IDS skyway connections on all four sides historically (Johnson design)

---

## 3. Nicollet plaza exit

| Fact | Value |
|------|-------|
| Role | Street wanted handoff; full asphalt grip |
| Read | Open plaza pull-off from IDS / Crystal Court toward Nicollet Mall |
| Material tag | `Grip_Street` (full) |

### Kit / greybox targets
- Asphalt / sidewalk plaza tile at skyway exit elevation drop
- Align Z / fall envelope with Map sheet (street below skyway deck)

### Photo / page refs
- Nicollet Mall at IDS / Crystal Court street level — search “IDS Center Nicollet Mall entrance Minneapolis”

---

## 4. Building context (silhouette only for slice)

| Item | Note |
|------|------|
| IDS Tower | 57 stories, ~775–792 ft — skyline landmark, not interior in slice |
| Complex | Tower + Crystal Court + Marquette Hotel + annex — slice uses court + skyways + one plaza exit |

---

## 5. Scale reminder (vs Los Santos)

Minneapolis downtown block is dense; IDS footprint should drive greybox, not freeway sprawl. Mission density per block > empty arterials.

---

## 6. Hand-off checklist

| Discipline | Bind to |
|------------|---------|
| Map | Atrium footprint, skyway lengths, Nicollet plaza placement |
| 3D | Pentagon shell, 18 ft clear modules, glass/rail, plaza exit |
| Physics | Grip  atrium / skyway / street; rail 100; fall ≥16.5 ft |
| Animation | Three loco blends + vault/fail + soft-steal |
| Gameplay | Soft-theft → heat dump → street wanted |

---

## 7. Parked (after IDS)

Minnetonka / Excelsior / Fletcher’s / Big Island / Bde Maka Ska refs stay in DesignBible appendix until slice ships. Do not block IDS greybox on those packs.

using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MPLSGTA.EditorTools
{
    // Menu: MPLSGTA > Build IDS Slice Scene
    // Builds Crystal Court, two skyways, the rail and stair edge, and Nicollet plaza from IdsNumbers,
    // then places grip, heat, and vault zones, the player, a camera, and a light.
    // Safe to run again: it overwrites Assets/MPLSGTA/Scenes/IDS_Slice.unity.
    public static class BuildIdsSlice
    {
        const string SceneDir = "Assets/MPLSGTA/Scenes";
        const string ScenePath = SceneDir + "/IDS_Slice.unity";
        const string MatDir = "Assets/MPLSGTA/Materials";
        const float Wall = 0.3f;

        static float M(float cm) => IdsNumbers.M(cm);

        [MenuItem("MPLSGTA/Build IDS Slice Scene")]
        public static void Build()
        {
            Directory.CreateDirectory(SceneDir);
            Directory.CreateDirectory(MatDir);
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

            var matAtrium = Mat("Atrium_Polished", new Color(0.85f, 0.85f, 0.9f));
            var matSkyway = Mat("Skyway_Deck", new Color(0.55f, 0.6f, 0.7f));
            var matGlass = Mat("Skyway_Glass", new Color(0.6f, 0.8f, 0.95f));
            var matStreet = Mat("Street_Asphalt", new Color(0.25f, 0.25f, 0.27f));
            var matRail = Mat("Rail", new Color(0.9f, 0.6f, 0.1f));

            var root = new GameObject("IDS_Slice").transform;
            var geo = new GameObject("Greybox").transform; geo.SetParent(root);
            var zones = new GameObject("Zones").transform; zones.SetParent(root);

            // Crystal Court atrium: floor, roof, four walls, opening on +X for Skyway1.
            float aw = M(IdsNumbers.AtriumWidthCm), ad = M(IdsNumbers.AtriumDepthCm), ah = M(IdsNumbers.AtriumHeightCm);
            float sw = M(IdsNumbers.SkywayWidthCm), sh = M(IdsNumbers.SkywayHeightCm), clear = M(IdsNumbers.SkywayClearWidthCm);
            float doorH = sh - Wall;
            Box("Atrium_Floor", new Vector3(0, -Wall / 2, 0), new Vector3(aw, Wall, ad), matAtrium, geo);
            Box("Atrium_Roof", new Vector3(0, ah + Wall / 2, 0), new Vector3(aw, Wall, ad), matGlass, geo);
            Box("Atrium_Wall_-X", new Vector3(-aw / 2, ah / 2, 0), new Vector3(Wall, ah, ad), matAtrium, geo);
            Box("Atrium_Wall_+Z", new Vector3(0, ah / 2, ad / 2), new Vector3(aw, ah, Wall), matAtrium, geo);
            Box("Atrium_Wall_-Z", new Vector3(0, ah / 2, -ad / 2), new Vector3(aw, ah, Wall), matAtrium, geo);
            float sideD = (ad - clear) / 2f;
            Box("Atrium_Wall_+X_A", new Vector3(aw / 2, ah / 2, clear / 2 + sideD / 2), new Vector3(Wall, ah, sideD), matAtrium, geo);
            Box("Atrium_Wall_+X_B", new Vector3(aw / 2, ah / 2, -(clear / 2 + sideD / 2)), new Vector3(Wall, ah, sideD), matAtrium, geo);
            Box("Atrium_Wall_+X_OverDoor", new Vector3(aw / 2, doorH + (ah - doorH) / 2, 0), new Vector3(Wall, ah - doorH, clear), matAtrium, geo);

            // Skyways: deck at 0, glass side walls, roof. Exterior 670 wide, 549 clear.
            float sideWall = (sw - clear) / 2f;
            float[] starts = { IdsNumbers.Skyway1StartXCm, IdsNumbers.Skyway2StartXCm };
            for (int i = 0; i < 2; i++)
            {
                float x0 = M(starts[i]), len = M(IdsNumbers.SkywayLengthCm), cx = x0 + len / 2;
                string n = "Skyway" + (i + 1);
                Box(n + "_Deck", new Vector3(cx, -Wall / 2, 0), new Vector3(len, Wall, sw), matSkyway, geo);
                Box(n + "_Roof", new Vector3(cx, sh - Wall / 2, 0), new Vector3(len, Wall, sw), matSkyway, geo);
                Box(n + "_Glass_+Z", new Vector3(cx, doorH / 2, clear / 2 + sideWall / 2), new Vector3(len, doorH, sideWall), matGlass, geo);
                Box(n + "_Glass_-Z", new Vector3(cx, doorH / 2, -(clear / 2 + sideWall / 2)), new Vector3(len, doorH, sideWall), matGlass, geo);
                Zone<GripZone>(n + "_Grip", new Vector3(cx, 1f, 0), new Vector3(len, 2f, clear), zones).Set(GripSurface.SkywayDeck);
                Zone<HeatZone>(n + "_Heat", new Vector3(cx, sh / 2, 0), new Vector3(len, sh, clear), zones).zoneType = HeatZoneType.Skyway;
            }

            // Skyway2 end: half is a 100 cm rail (vault edge), half is a stair ramp down to Nicollet.
            float endX = M(IdsNumbers.Skyway2EndXCm), rail = M(IdsNumbers.RailHeightCm), street = M(IdsNumbers.StreetZCm);
            float half = clear / 2f;
            Box("Vault_Rail", new Vector3(endX, rail / 2, -half / 2), new Vector3(0.08f, rail, half), matRail, geo);
            var vault = Zone<VaultZone>("Vault_Zone", new Vector3(endX - 0.6f, 1f, -half / 2), new Vector3(1.2f, 2f, half), zones);
            vault.overRailDirection = Vector3.right;
            float rampRun = M(IdsNumbers.SkywayLengthCm), rampDrop = -street;
            float rampLen = Mathf.Sqrt(rampRun * rampRun + rampDrop * rampDrop);
            float rampAngle = Mathf.Atan2(rampDrop, rampRun) * Mathf.Rad2Deg;
            var ramp = Box("Stair_Ramp_To_Nicollet", new Vector3(endX + rampRun / 2, street / 2 - Wall / 2, half / 2), new Vector3(rampLen, Wall, half), matSkyway, geo);
            ramp.transform.rotation = Quaternion.Euler(0, 0, -rampAngle);

            // Nicollet plaza slab (top at street level) plus street apron.
            float pl = M(IdsNumbers.PlazaLengthCm), pw = M(IdsNumbers.PlazaWidthCm), pt = M(IdsNumbers.PlazaThicknessCm);
            float plazaCx = endX + pl / 2;
            Box("Nicollet_Plaza", new Vector3(plazaCx, street - pt / 2, 0), new Vector3(pl, pt, pw), matStreet, geo);
            float apron = M(IdsNumbers.StreetApronLengthCm);
            Box("Nicollet_Street_Apron", new Vector3(endX + pl + apron / 2, street - pt / 2, 0), new Vector3(apron, pt, pw), matStreet, geo);
            float streetLen = pl + apron, streetCx = endX + streetLen / 2;
            Zone<GripZone>("Street_Grip", new Vector3(streetCx, street + 1f, 0), new Vector3(streetLen, 2f, pw), zones).Set(GripSurface.StreetAsphalt);
            Zone<HeatZone>("Street_Heat", new Vector3(streetCx, street + 2f, 0), new Vector3(streetLen, 4f, pw), zones).zoneType = HeatZoneType.Street;

            // Atrium zones.
            Zone<GripZone>("Atrium_Grip", new Vector3(0, 1f, 0), new Vector3(aw, 2f, ad), zones).Set(GripSurface.AtriumPolished);
            Zone<HeatZone>("Atrium_Heat", new Vector3(0, ah / 2, 0), new Vector3(aw, ah, ad), zones).zoneType = HeatZoneType.SoftTheft;

            // Light.
            var sun = new GameObject("Sun").AddComponent<Light>();
            sun.type = LightType.Directional;
            sun.intensity = 1.1f;
            sun.transform.rotation = Quaternion.Euler(50, -30, 0);
            sun.transform.SetParent(root);
            RenderSettings.ambientLight = new Color(0.45f, 0.45f, 0.5f);

            // Spawn, player, camera, HUD.
            var spawn = new GameObject("PlayerSpawn").transform;
            spawn.position = new Vector3(-aw / 4, 0.1f, 0);
            spawn.rotation = Quaternion.LookRotation(Vector3.right);
            spawn.SetParent(root);

            var playerGo = new GameObject("Player");
            playerGo.transform.SetPositionAndRotation(spawn.position + Vector3.up * 1f, spawn.rotation);
            var cc = playerGo.AddComponent<CharacterController>();
            cc.height = 1.8f; cc.radius = 0.35f; cc.center = Vector3.zero; cc.slopeLimit = 45f; cc.stepOffset = 0.35f;
            var body = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            body.name = "Body";
            Object.DestroyImmediate(body.GetComponent<Collider>());
            body.transform.SetParent(playerGo.transform, false);
            body.transform.localScale = new Vector3(0.7f, 0.9f, 0.7f);
            body.GetComponent<Renderer>().sharedMaterial = matRail;
            var wanted = playerGo.AddComponent<WantedSystem>();
            var player = playerGo.AddComponent<MPLSPlayer>();
            player.spawnPoint = spawn;

            var pivot = new GameObject("CameraPivot").transform;
            pivot.SetParent(playerGo.transform, false);
            pivot.localPosition = new Vector3(0, 0.6f, 0);
            var camGo = new GameObject("Main Camera");
            camGo.tag = "MainCamera";
            var cam = camGo.AddComponent<Camera>();
            cam.nearClipPlane = 0.1f; cam.farClipPlane = 1000f;
            camGo.AddComponent<AudioListener>();
            camGo.transform.SetParent(pivot, false);
            camGo.transform.localPosition = new Vector3(0.5f, 0.4f, -3.5f);
            player.cameraPivot = pivot;

            var hud = playerGo.AddComponent<DebugHud>();
            hud.player = player; hud.wanted = wanted;

            EditorSceneManager.SaveScene(scene, ScenePath);
            EditorBuildSettings.scenes = new[] { new EditorBuildSettingsScene(ScenePath, true) };
            AssetDatabase.SaveAssets();
            Debug.Log("MPLSGTA: built " + ScenePath + ". Press Play.");
        }

        static void Set(this GripZone z, GripSurface s) { z.surface = s; z.gripMultiplier = GripZone.DefaultFor(s); }

        static GameObject Box(string name, Vector3 center, Vector3 size, Material mat, Transform parent)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.name = name;
            go.transform.SetParent(parent, false);
            go.transform.position = center;
            go.transform.localScale = size;
            go.GetComponent<Renderer>().sharedMaterial = mat;
            go.isStatic = true;
            return go;
        }

        static T Zone<T>(string name, Vector3 center, Vector3 size, Transform parent) where T : Component
        {
            var go = new GameObject(name);
            go.transform.SetParent(parent, false);
            go.transform.position = center;
            var bc = go.AddComponent<BoxCollider>();
            bc.isTrigger = true;
            bc.size = size;
            return go.AddComponent<T>();
        }

        static Material Mat(string name, Color c)
        {
            string path = MatDir + "/M_" + name + ".mat";
            var m = AssetDatabase.LoadAssetAtPath<Material>(path);
            if (m == null)
            {
                var shader = Shader.Find("Standard") ?? Shader.Find("Universal Render Pipeline/Lit");
                m = new Material(shader);
                AssetDatabase.CreateAsset(m, path);
            }
            m.color = c;
            EditorUtility.SetDirty(m);
            return m;
        }
    }
}

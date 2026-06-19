using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering;

namespace Elysia.Editor
{
    public static class WorldSetupTool
    {
        const string GameRoot   = "Assets/_Game";
        const string MatEnv     = GameRoot + "/Materials/Environment";
        const string MatChar    = GameRoot + "/Materials/Characters";
        const string ScenesPath = GameRoot + "/Scenes";

        [MenuItem("Elysia/Setup/Create World Scene")]
        public static void CreateWorldScene()
        {
            if (!EditorUtility.DisplayDialog(
                "Crear escena de mundo",
                "Se crearán los materiales y la escena Mundo_Prototipo.\n¿Continuar?",
                "Crear", "Cancelar"))
                return;

            EnsureFolders();
            CreateMaterials();
            BuildScene();
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Debug.Log("[Elysia] World setup completado.");
        }

        // ─────────────────────────────────────────────────────────────────────
        // Folders
        // ─────────────────────────────────────────────────────────────────────

        static void EnsureFolders()
        {
            string[] paths =
            {
                GameRoot,
                GameRoot + "/Animations",
                GameRoot + "/Animations/Player",
                GameRoot + "/Animations/Enemy",
                GameRoot + "/Animations/NPC",
                GameRoot + "/Audio",
                GameRoot + "/Audio/Music",
                GameRoot + "/Audio/SFX",
                GameRoot + "/Fonts",
                GameRoot + "/Materials",
                MatEnv,
                MatChar,
                GameRoot + "/Materials/UI",
                GameRoot + "/Models",
                GameRoot + "/Models/Characters",
                GameRoot + "/Models/Environment",
                GameRoot + "/Models/Props",
                GameRoot + "/Prefabs",
                GameRoot + "/Prefabs/Characters",
                GameRoot + "/Prefabs/Combat",
                GameRoot + "/Prefabs/Environment",
                GameRoot + "/Prefabs/UI",
                GameRoot + "/Prefabs/VFX",
                ScenesPath,
                GameRoot + "/ScriptableObjects",
                GameRoot + "/ScriptableObjects/Characters",
                GameRoot + "/ScriptableObjects/Dialogues",
                GameRoot + "/ScriptableObjects/Items",
                GameRoot + "/Scripts",
                GameRoot + "/Scripts/Combat",
                GameRoot + "/Scripts/Core",
                GameRoot + "/Scripts/Dialogue",
                GameRoot + "/Scripts/Editor",
                GameRoot + "/Scripts/Enemy",
                GameRoot + "/Scripts/Player",
                GameRoot + "/Scripts/UI",
                GameRoot + "/Scripts/World",
                GameRoot + "/Shaders",
                GameRoot + "/Sprites",
                GameRoot + "/VFX"
            };

            foreach (string path in paths)
            {
                if (AssetDatabase.IsValidFolder(path)) continue;
                string parent = Path.GetDirectoryName(path)!.Replace('\\', '/');
                string name   = Path.GetFileName(path);
                AssetDatabase.CreateFolder(parent, name);
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // Materials
        // ─────────────────────────────────────────────────────────────────────

        static void CreateMaterials()
        {
            MakeMat("Floor_Mat",   MatEnv,  "#8C8C8C");
            MakeMat("Wall_Mat",    MatEnv,  "#4A4A4A");
            MakeMat("Wall_BG_Mat", MatEnv,  "#2A2A2A");
            MakeMat("Pillar_Mat",  MatEnv,  "#6A6A6A");
            MakeMat("Crate_Mat",   MatEnv,  "#8B6914");
            MakeMat("Player_Mat",  MatChar, "#00BCD4");
        }

        static void MakeMat(string matName, string folder, string hex)
        {
            string path = $"{folder}/{matName}.mat";
            if (AssetDatabase.LoadAssetAtPath<Material>(path) != null) return;

            Shader shader = Shader.Find("Universal Render Pipeline/Lit")
                         ?? Shader.Find("Standard");

            var mat = new Material(shader) { name = matName };
            if (ColorUtility.TryParseHtmlString(hex, out Color c))
                mat.SetColor("_BaseColor", c);

            AssetDatabase.CreateAsset(mat, path);
        }

        static Material Mat(string folder, string name) =>
            AssetDatabase.LoadAssetAtPath<Material>($"{folder}/{name}.mat");

        // ─────────────────────────────────────────────────────────────────────
        // Scene
        // ─────────────────────────────────────────────────────────────────────

        static void BuildScene()
        {
            string scenePath = $"{ScenesPath}/Mundo_Prototipo.unity";

            var scene = EditorSceneManager.NewScene(
                NewSceneSetup.EmptyScene, NewSceneMode.Single);

            // Ambient light — warm dark grey so nothing is pitch black
            RenderSettings.ambientMode  = AmbientMode.Flat;
            RenderSettings.ambientLight = new Color(0.15f, 0.12f, 0.10f);
            RenderSettings.fog          = false;

            // ── Environment ──────────────────────────────────────────────────
            var env = new GameObject("Environment");

            // Floor: Plane mesh = 10×10 u at scale (1,1,1)  →  scale ×0.85/1.2 = 8.5×12 u
            Place(PrimitiveType.Plane, "Floor", env.transform,
                new Vector3(0f, 0f, 3f), new Vector3(0.85f, 1f, 1.2f),
                Mat(MatEnv, "Floor_Mat"));

            var walls = Group("Walls", env.transform);
            Place(PrimitiveType.Cube, "Wall_Back",  walls, new Vector3(0f,  2f, 9f),   new Vector3(10f,  4f, 0.5f), Mat(MatEnv, "Wall_Mat"));
            Place(PrimitiveType.Cube, "Wall_Left",  walls, new Vector3(-5f, 2f, 3f),   new Vector3(0.5f, 4f, 12f),  Mat(MatEnv, "Wall_Mat"));
            Place(PrimitiveType.Cube, "Wall_Right", walls, new Vector3(5f,  2f, 3f),   new Vector3(0.5f, 4f, 12f),  Mat(MatEnv, "Wall_Mat"));

            // Pillars: Cylinder mesh = 1 u diameter, 2 u tall → scale (0.4, 1.5, 0.4) = 0.4Ø × 3 u tall
            var props = Group("Props", env.transform);
            Place(PrimitiveType.Cylinder, "Pillar_01", props, new Vector3(-3f, 1.5f, 2f), new Vector3(0.4f, 1.5f, 0.4f), Mat(MatEnv, "Pillar_Mat"));
            Place(PrimitiveType.Cylinder, "Pillar_02", props, new Vector3( 3f, 1.5f, 2f), new Vector3(0.4f, 1.5f, 0.4f), Mat(MatEnv, "Pillar_Mat"));
            Place(PrimitiveType.Cylinder, "Pillar_03", props, new Vector3(-3f, 1.5f, 7f), new Vector3(0.4f, 1.5f, 0.4f), Mat(MatEnv, "Pillar_Mat"));
            Place(PrimitiveType.Cylinder, "Pillar_04", props, new Vector3( 3f, 1.5f, 7f), new Vector3(0.4f, 1.5f, 0.4f), Mat(MatEnv, "Pillar_Mat"));
            Place(PrimitiveType.Cube, "Crate_01", props, new Vector3(-2f, 0.4f, 4f), Vector3.one * 0.8f, Mat(MatEnv, "Crate_Mat"));
            Place(PrimitiveType.Cube, "Crate_02", props, new Vector3( 2f, 0.4f, 6f), Vector3.one * 0.8f, Mat(MatEnv, "Crate_Mat"));

            // Background depth — darker layers behind the walls
            var bg = Group("Background", env.transform);
            Place(PrimitiveType.Cube, "BG_Wall",  bg, new Vector3(0f,  3f, 10.5f), new Vector3(12f,  6f, 0.5f), Mat(MatEnv, "Wall_BG_Mat"));
            Place(PrimitiveType.Cube, "BG_Left",  bg, new Vector3(-6f, 3f, 3f),    new Vector3(0.5f, 6f, 14f),  Mat(MatEnv, "Wall_BG_Mat"));
            Place(PrimitiveType.Cube, "BG_Right", bg, new Vector3( 6f, 3f, 3f),    new Vector3(0.5f, 6f, 14f),  Mat(MatEnv, "Wall_BG_Mat"));

            // ── Lighting ─────────────────────────────────────────────────────
            var lighting = new GameObject("Lighting");

            var dirGO  = new GameObject("Directional_Light");
            dirGO.transform.SetParent(lighting.transform);
            dirGO.transform.rotation = Quaternion.Euler(-40f, 30f, 0f);
            var dirL  = dirGO.AddComponent<Light>();
            dirL.type      = LightType.Directional;
            dirL.intensity = 1.2f;
            dirL.color     = new Color(1f, 0.95f, 0.85f);

            var ptGO  = new GameObject("Point_Light_01");
            ptGO.transform.SetParent(lighting.transform);
            ptGO.transform.position = new Vector3(0f, 3f, 5f);
            var ptL   = ptGO.AddComponent<Light>();
            ptL.type      = LightType.Point;
            ptL.intensity = 2f;
            ptL.range     = 10f;
            ptL.color     = new Color(1f, 0.7f, 0.3f);

            // ── Camera (static test camera for PR1) ──────────────────────────
            var camGO = new GameObject("Main Camera");
            camGO.tag = "MainCamera";
            camGO.AddComponent<Camera>();
            camGO.AddComponent<AudioListener>();
            camGO.transform.position = new Vector3(0f, 5f, -4f);
            camGO.transform.rotation = Quaternion.Euler(25f, 0f, 0f);

            EditorSceneManager.SaveScene(scene, scenePath);
            EditorSceneManager.OpenScene(scenePath);

            Debug.Log($"[Elysia] Escena guardada en {scenePath}");
        }

        // ─────────────────────────────────────────────────────────────────────
        // Helpers
        // ─────────────────────────────────────────────────────────────────────

        static Transform Group(string name, Transform parent)
        {
            var go = new GameObject(name);
            go.transform.SetParent(parent);
            return go.transform;
        }

        static void Place(PrimitiveType type, string name, Transform parent,
            Vector3 pos, Vector3 scale, Material mat)
        {
            var go = GameObject.CreatePrimitive(type);
            go.name = name;
            go.transform.SetParent(parent);
            go.transform.localPosition = pos;
            go.transform.localScale    = scale;
            if (mat != null)
                go.GetComponent<Renderer>().sharedMaterial = mat;
        }
    }
}

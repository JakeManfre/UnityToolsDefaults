using System.IO;
using UnityEditor;
using UnityEngine;

public static class UnityDefaultDirectories
{
    private static readonly string _root = "_Project";
    private static readonly string[] _direcotires =
    {
        "Editor",
        "Plugins",
        "Animations",
        "Models",
        "Prefabs",
        "Source",
        "Scenes",
        "Materials",
        "Shaders",
        "Images"
    };

    [MenuItem("Tools/Create Default Directories")]
    public static void CreateDefaultDirectories()
    {
        string path = Path.Combine(Application.dataPath, _root);
        foreach (var newDirectory in _direcotires)
        {
            Directory.CreateDirectory(Path.Combine(path, newDirectory));
        }

        AssetDatabase.Refresh();
    }
}

using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public static class UnityDefaultPackages
{
#if UNITY_EDITOR
    [MenuItem("Tools/Set Default Packages")]
    public static async void LoadNewManifest()
    {
        // github gist link: https://gist.github.com/JakeManfre/9c932a75a476ae36d0ffea8520ddd5f4
        var url = GetGistURL("9c932a75a476ae36d0ffea8520ddd5f4");
        var contents = await GetContents(url);
        ReplacePackageFile(contents);
    }

    private static string GetGistURL(string id, string user = "JakeManfre")
    {
        return $"https://gist.githubusercontent.com/{user}/{id}/raw";
    }

    private static async Task<string> GetContents(string url)
    {
        using var client = new HttpClient();
        var response = await client.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();
        return content;
    }

    private static void ReplacePackageFile(string contents)
    {
        var filePath = Path.Combine(Application.dataPath, "../Packages/manifest.json");
        File.WriteAllText(filePath, contents);
        UnityEditor.PackageManager.Client.Resolve();
    }
#endif
}

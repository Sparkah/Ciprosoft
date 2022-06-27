using UnityEngine;

namespace Helpers
{
    public static class JsonUtils
    {
        public static T ImportJson<T>(string path)
        {
            TextAsset jsonTextFile = Resources.Load<TextAsset>(path);
            return JsonUtility.FromJson<T>(jsonTextFile.text);
        }
    }
}
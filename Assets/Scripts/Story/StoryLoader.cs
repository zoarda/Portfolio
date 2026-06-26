using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public static class StoryLoader
{
    [Serializable]
    private class StoryWrapper
    {
        public List<StoryNode> list;
    }

    public static Dictionary<int, StoryNode> LoadStory(string fileName)
    {
        Dictionary<int, StoryNode> dict = new Dictionary<int, StoryNode>();

        try
        {
            string path = Path.Combine(Application.streamingAssetsPath, fileName);
            string json = "";

#if UNITY_WEBGL && !UNITY_EDITOR
            // WebGL ¤£¯à¥Î File.ReadAllText
            using (var www = UnityEngine.Networking.UnityWebRequest.Get(path))
            {
                www.SendWebRequest();

                while (!www.isDone) { }

                if (www.result != UnityEngine.Networking.UnityWebRequest.Result.Success)
                {
                    Debug.LogError($"[StoryLoader] Load Failed: {www.error}");
                    return dict;
                }

                json = www.downloadHandler.text;
            }
#else

            json = File.ReadAllText(path, Encoding.UTF8);
            Debug.Log(json);
#endif

            StoryWrapper wrapper = JsonUtility.FromJson<StoryWrapper>(json);

            if (wrapper == null || wrapper.list == null)
            {
                Debug.LogError("[StoryLoader] JSON parse failed");
                return dict;
            }

            foreach (var node in wrapper.list)
            {
                dict[node.id] = node;
            }

            Debug.Log($"[StoryLoader] Load Success: {dict.Count} nodes");
        }
        catch (Exception e)
        {
            Debug.LogError($"[StoryLoader] Exception: {e.Message}");
        }

        return dict;
    }
}
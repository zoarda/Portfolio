using UnityEngine;
using System.IO;
using System;

public static class SaveManager
{
    private static string path => Path.Combine(Application.persistentDataPath, "save.json");

    public static void Save(int currentId)
    {
        try
        {
            SaveData data = new SaveData
            {
                currentId = currentId
            };

            string json = JsonUtility.ToJson(data, true); // pretty print
            File.WriteAllText(path, json);

            Debug.Log($"[SaveManager] Save Success: {path}");
        }
        catch (Exception e)
        {
            Debug.LogError($"[SaveManager] Save Failed: {e.Message}");
        }
    }

    public static int Load()
    {
        try
        {
            if (!File.Exists(path))
            {
                Debug.Log("[SaveManager] No save file, start from 1");
                return 1;
            }

            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            if (data == null)
            {
                Debug.LogWarning("[SaveManager] SaveData is null, reset to 1");
                return 1;
            }

            Debug.Log($"[SaveManager] Load Success: {data.currentId}");
            return data.currentId;
        }
        catch (Exception e)
        {
            Debug.LogError($"[SaveManager] Load Failed: {e.Message}");
            return 1;
        }
    }
}
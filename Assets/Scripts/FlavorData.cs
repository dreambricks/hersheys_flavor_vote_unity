using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public class FlavorData
{
    public int pt_bolo;
    public int pt_beijinho;

    public static void SaveToJson(FlavorData flavorData)
    {

        string folderJson = Path.Combine(Application.streamingAssetsPath, "flavorData");

        if (!Directory.Exists(folderJson))
        {
            Directory.CreateDirectory(folderJson);
        }

        string filepath = Path.Combine(folderJson, "FlavorData.json");

        string jsonData = JsonConvert.SerializeObject(flavorData);

        File.WriteAllText(filepath, jsonData);
    }

    public static FlavorData LoadFromJson()
    {
        string folderJson = Path.Combine(Application.streamingAssetsPath, "flavorData");

        if (!Directory.Exists(folderJson))
        {
            return null;
        }

        string filepath = Path.Combine(folderJson, "FlavorData.json");

        string jsonData = File.ReadAllText(filepath);

        FlavorData flavorData = JsonConvert.DeserializeObject<FlavorData>(jsonData);

        return flavorData;
    }
}

using System.IO;
using UnityEngine;
using System;

public class GraphicsQualitySettingsSaver
{
    private readonly string _name = "GraphicsQuality";

    public void InitSettingsConfig(in object target)
    {
        if (File.Exists(GetFilePath()))
            throw new InvalidOperationException("Json has been initialized");

        var json = JsonUtility.ToJson(target);
        File.WriteAllText(GetFilePath(), json);
    }

    public void SaveSettingsConfig(in object target)
    {
        if (File.Exists(GetFilePath()) == false)
            throw new InvalidOperationException("Json isn't initialized");

        var json = JsonUtility.ToJson(target);

        File.WriteAllText(GetFilePath(), json);
    }

    public void OverwriteSettingsConfig(in object target)
    {
        if (File.Exists(GetFilePath()) == false)
            throw new InvalidOperationException("Json isn't initialized");

        var json = File.ReadAllText(GetFilePath());

        JsonUtility.FromJsonOverwrite(json, target);
    }

    private string GetFilePath()
    {
        return Application.persistentDataPath + $"{_name}.json";
    }
}
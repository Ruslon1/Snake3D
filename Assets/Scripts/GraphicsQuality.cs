using UnityEngine;
using TMPro;

public class GraphicsQuality : MonoBehaviour, ISavable
{
    private TMP_Dropdown _dropdown;
    private GraphicsQualitySettingsSaver _qualitySettingsSaver = new GraphicsQualitySettingsSaver();

    [HideInInspector] [SerializeField] private int _qualityLevel = 2;

    private void Awake()
    {
        _dropdown = GetComponent<TMP_Dropdown>();

        InitSettings();
        SetQualityBySavedSettings();
    }

    public void SetQuality()
    {
        _qualityLevel = _dropdown.value;
        QualitySettings.SetQualityLevel(_qualityLevel);
        _qualitySettingsSaver.SaveSettingsConfig(this);
    }

    private void SetQualityBySavedSettings()
    {
        QualitySettings.SetQualityLevel(_qualityLevel);
        _qualitySettingsSaver.SaveSettingsConfig(this);
    }
    
    private void InitSettings()
    {
        try
        {
            _qualitySettingsSaver.InitSettingsConfig(this);
        }
        catch
        {
            _qualitySettingsSaver.OverwriteSettingsConfig(this);
        }
    }

    private void OnApplicationQuit()
    {
        _qualitySettingsSaver.OverwriteSettingsConfig(this);
    }
}
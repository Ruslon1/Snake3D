using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] private List<GameObject> _interferingObjects;
    [SerializeField] private SettingUI _settingObject;

    public void OpenSettings()
    {
        _interferingObjects.ForEach(i => i.SetActive(false));
        _settingObject.gameObject.SetActive(true);
    }

    public void CloseSettings()
    {
        _interferingObjects.ForEach(i => i.SetActive(true));
        _settingObject.gameObject.SetActive(false);
        gameObject.SetActive(true);
    }
}

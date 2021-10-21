using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private StartGameUI _startGame;
    [SerializeField] private SettingsButton _settingsButton;

    private void OnEnable()
    {
        _settingsButton.gameObject.SetActive(false);
    }

    public void PauseGame()
    {
        _startGame.gameObject.SetActive(true);
        _settingsButton.gameObject.SetActive(true);
    }
}

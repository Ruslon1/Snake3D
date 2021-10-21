using UnityEngine;

public class StartGameUI : MonoBehaviour
{
    [SerializeField] private GameObject _mainObject;

    private void OnEnable()
    {
        _mainObject.SetActive(false);
    }

    public void StartGame()
    {
        _mainObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
 
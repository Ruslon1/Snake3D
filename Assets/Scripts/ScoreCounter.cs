using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _counter;

    private int _score = 0;

    public void AddScore()
    {
        _score++;
        _counter.text = _score.ToString();
    }
}
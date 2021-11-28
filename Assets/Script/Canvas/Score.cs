using UnityEngine;
using UnityEngine.UI;
using System;

public class Score : MonoBehaviour
{
    [SerializeField] private Text _scoretext;

    private int _score;

    public void IncreseScore()
    {
        _score++;
        WithdrawalScore();
    }

    private void WithdrawalScore()
    {
        _scoretext.text = Convert.ToString(_score);
    }
}

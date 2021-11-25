using UnityEngine;
using UnityEngine.UI;
using System;

public class AccrualAndWithdrawalPoints : MonoBehaviour
{
    [SerializeField] private Text _scoretext;

    private int _score;

    public void IncreseScore()
    {
        _score++;
        WithdrawalPoints();
    }

    private void WithdrawalPoints()
    {
        _scoretext.text = Convert.ToString(_score);
    }
}

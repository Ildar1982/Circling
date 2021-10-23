using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Accrualofpoints : MonoBehaviour
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

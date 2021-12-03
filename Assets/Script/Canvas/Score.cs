using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Text))]
public class Score : MonoBehaviour
{
    private Text _text;
    private int _quantity;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    public void Increse()
    {
        _quantity++;
        Withdrawal();
    }

    private void Withdrawal()
    {
        _text.text = Convert.ToString(_quantity);
    }
}

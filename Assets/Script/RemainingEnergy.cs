using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainingEnergy : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] Dron _drone;

    private void OnEnable()
    {
        _drone.ChangeEnergyUp += ChangeEnergyUp;
        _drone.ChangeEnergyDown += ChangeEnergyDown;
    }
    private void OnDisable()
    {
        _drone.ChangeEnergyUp -= ChangeEnergyUp;
        _drone.ChangeEnergyDown -= ChangeEnergyDown;
    }
    private void ChangeEnergyUp()
    {
        _image.fillAmount = _image.fillAmount + 0.01f;
    }
    private void ChangeEnergyDown()
    {
        _image.fillAmount = _image.fillAmount - 0.1f;
    }
}

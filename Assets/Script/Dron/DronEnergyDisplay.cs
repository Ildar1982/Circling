using UnityEngine;
using UnityEngine.UI;

public class DronEnergyDisplay : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private DronePowerSupply _charging;
    [SerializeField] private DroneMovement _movement;

    private float _changedPart = 0.05f;

    private void OnEnable()
    {
        _charging.IncreasedEnergy += ChangeEnergyUp;
        _movement.DecreasedEnergy += ChangeEnergyDown;
    }

    private void OnDisable()
    {
        _charging.IncreasedEnergy -= ChangeEnergyUp;
        _movement.DecreasedEnergy -= ChangeEnergyDown;
    }

    private void ChangeEnergyUp()
    {         
        _image.fillAmount = _image.fillAmount + _changedPart;
    }

    private void ChangeEnergyDown()
    {
        _image.fillAmount = _image.fillAmount - _changedPart;
    }
}

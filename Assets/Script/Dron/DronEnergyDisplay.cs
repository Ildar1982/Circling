using UnityEngine;
using UnityEngine.UI;

public class DronEnergyDisplay : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private DronePowerSupply _chargingDrone;
    [SerializeField] private DroneMovement _drone;

    private float _changedPart = 0.05f;

    private void OnEnable()
    {
        _chargingDrone.IncreasedEnergy += ChangeEnergyUp;
        _drone.DecreasedEnergy += ChangeEnergyDown;
    }

    private void OnDisable()
    {
        _chargingDrone.IncreasedEnergy -= ChangeEnergyUp;
        _drone.DecreasedEnergy -= ChangeEnergyDown;
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

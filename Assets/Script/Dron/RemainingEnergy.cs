using UnityEngine;
using UnityEngine.UI;

public class RemainingEnergy : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private ChargingDron _chargingDrone;
    [SerializeField] private MoveDron _drone;

    private void OnEnable()
    {
        _chargingDrone.ChangeEnergyUp += ChangeEnergyUp;
        _drone.ChangeEnergyDown += ChangeEnergyDown;
    }
    private void OnDisable()
    {
        _chargingDrone.ChangeEnergyUp -= ChangeEnergyUp;
        _drone.ChangeEnergyDown -= ChangeEnergyDown;
    }
    private void ChangeEnergyUp()
    {
        _image.fillAmount = _image.fillAmount + 0.05f;
    }
    private void ChangeEnergyDown()
    {
        _image.fillAmount = _image.fillAmount - 0.1f;
    }
}

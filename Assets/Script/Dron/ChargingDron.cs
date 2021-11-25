using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ChargingDron : MonoBehaviour
{
    [SerializeField] private DronControlButton _dronControlButton;
    [SerializeField] private float _changeEnergyCharge;
    [SerializeField] private MoveDron _moveDron;

    private WaitForSeconds waitSecondsEnergy = new WaitForSeconds(0.1f);
    private float _energy;
    private float _energyMax;

    public event UnityAction ChangeEnergyUp;

    private void OnEnable()
    {
        _dronControlButton.ChargingDron += Charging;
        _dronControlButton.UnChargingDron += StopCharging;
    }

    private void OnDisable()
    {
        _dronControlButton.ChargingDron -= Charging;
        _dronControlButton.UnChargingDron -= StopCharging;
    }

    private void Charging()
    {
        StartCoroutine(Energy());
    }

    private void StopCharging()
    {
        StopAllCoroutines();
        _moveDron.DronEnergyCharging(_energy);
    }

    public void DronEnergyInit(float energy, float energyMax)
    {
        _energy = energy;
        _energyMax = energyMax;
    }

    private IEnumerator Energy()
    {
        while (true)
        {
            yield return waitSecondsEnergy;
            if (_energy < _energyMax)
            {
                _energy = _energy + _changeEnergyCharge;
                ChangeEnergyUp?.Invoke();
            }
        }
    }
}

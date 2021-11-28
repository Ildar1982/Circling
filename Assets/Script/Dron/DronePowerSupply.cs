using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DronePowerSupply : MonoBehaviour
{
    [SerializeField] private DronControlButton _dronControlButton;
    [SerializeField] private float _changeEnergyCharge;
    [SerializeField] private DroneMovement _moveDron;
    
    private float _energy;
    private float _energyMax;

    public event UnityAction IncreasedEnergy;

    private void OnEnable()
    {
        _dronControlButton.ChargingStarted += Charge;
        _dronControlButton.ChargingStopped += StopCharging;
    }

    private void OnDisable()
    {
        _dronControlButton.ChargingStarted -= Charge;
        _dronControlButton.ChargingStopped -= StopCharging;
    }

    private void Charge()
    {
        StartCoroutine(AddEnergy());
    }

    private void StopCharging()
    {
        StopAllCoroutines();
        _moveDron.DronEnergyCharging(_energy);
    }

    public void EnergyInit(float energy, float energyMax)
    {
        _energy = energy;
        _energyMax = energyMax;
    }

    private IEnumerator AddEnergy()
    {
       WaitForSeconds waitSecondsEnergy = new WaitForSeconds(0.1f);

        while (true)
        {
            yield return waitSecondsEnergy;
            if (_energy < _energyMax)
            {
                _energy = _energy + _changeEnergyCharge;
                IncreasedEnergy?.Invoke();
            }
        }
    }
}

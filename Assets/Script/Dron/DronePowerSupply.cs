using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DronePowerSupply : MonoBehaviour
{
    [SerializeField] private DronControlButton _controlButton;
    [SerializeField] private float _changeEnergyCharge;
    [SerializeField] private DroneMovement _movement;

    private float _energy;
    private float _energyMax;

    public event UnityAction IncreasedEnergy;

    private void OnEnable()
    {
        _controlButton.ChargingStarted += Charge;
        _controlButton.ChargingStopped += StopCharging;
    }

    private void OnDisable()
    {
        _controlButton.ChargingStarted -= Charge;
        _controlButton.ChargingStopped -= StopCharging;
    }

    private void Charge()
    {
        StartCoroutine(AddEnergy());
    }

    private void StopCharging()
    {
        _movement.Charge(_energy);
    }

    public void InitEnergy(float energy, float energyMax)
    {
        _energy = energy;
        _energyMax = energyMax;
    }

    private IEnumerator AddEnergy()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (_energy < _energyMax)
            {
                _energy = _energy + _changeEnergyCharge;
                IncreasedEnergy?.Invoke();
            }
        }
    }
}
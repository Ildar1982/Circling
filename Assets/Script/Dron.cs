using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dron : MonoBehaviour
{
    [SerializeField] private float _parametrAEllipse;
    [SerializeField] private float _parametrBEllipse;
    [SerializeField] private float _angleAlfaEllipseStartingPosition;
    [SerializeField] private float _angleAlfaEllipseStartingPositionOld;
    [SerializeField] private float _speedAngleEllipse;
    [SerializeField] private float _energy;
    [SerializeField] private float _changeEnergy;
    [SerializeField] private float _changeEnergyCharge;
    [SerializeField] private float _currentspeedDron;
    [SerializeField] private Field _field;
    private Transform _oldTransform;
    private Transform _currentTransform;
    private float _currentEllipseX;
    private float _currentEllipseY;
    private bool _energyDown = false;
    public event UnityAction ChangeEnergyUp;
    public event UnityAction ChangeEnergyDown;
    private float _energyMax;
    private float _speedDron;
    private WaitForSeconds waitSecondsEnergy = new WaitForSeconds(0.1f);
    public bool FeildDefender = true;

    private void Start()
    {
        _oldTransform = GetComponent<Transform>();
        _currentTransform = GetComponent<Transform>();
        _energyMax = _energy;
    }

    private void Update()
    {
        RotateInAnEllipse();
        _angleAlfaEllipseStartingPositionOld = _angleAlfaEllipseStartingPosition % 6.28f;
        if (Mathf.Round(_angleAlfaEllipseStartingPositionOld) == 0 && _energyDown == false)
        {
            _energy = _energy - _changeEnergy;
            ChangeEnergyDown?.Invoke();
            _energyDown = true;
        }
        if (Mathf.Round(_angleAlfaEllipseStartingPositionOld) == 1)
        {
            _energyDown = false;
        }
    }
    private void RotateInAnEllipse()
    {
        _angleAlfaEllipseStartingPosition = _angleAlfaEllipseStartingPosition + (_speedAngleEllipse * _energy * _currentspeedDron);
        _currentEllipseX = _parametrAEllipse * Mathf.Cos(_angleAlfaEllipseStartingPosition);
        _currentEllipseY = _parametrBEllipse * Mathf.Sin(_angleAlfaEllipseStartingPosition);
        _oldTransform.transform.position = transform.position;
        _currentTransform.transform.position = new Vector2(_currentEllipseX, _currentEllipseY);
        transform.position = Vector2.MoveTowards(_currentTransform.transform.position, _oldTransform.transform.position, Time.deltaTime);
    }
    public void ButtonChargingDron()
    {
        StartCoroutine(EnergyButton());
        _speedDron = _currentspeedDron;
        _currentspeedDron = 0;
        _field.FieldDefender = false;
        _field.Particle.Stop();
        _field.SpriteRenderer.enabled = false;
    }
    public void ButtonChargingDronStop()
    {
        StopAllCoroutines();
        _currentspeedDron = _speedDron;
        _field.FieldDefender = true;
        _field.Particle.Play();
        _field.SpriteRenderer.enabled = true;
    }
    private IEnumerator EnergyButton()
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
    public void ChangePosition()
    {
        _angleAlfaEllipseStartingPosition += 1;
    }
}

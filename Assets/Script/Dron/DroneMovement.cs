using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class DroneMovement : MonoBehaviour
{
    [SerializeField] private float _parametrAEllipse;
    [SerializeField] private float _parametrBEllipse;
    [SerializeField] private float _angleAlfaEllipseStartingPosition;
    [SerializeField] private float _energy;
    [SerializeField] private float _changeEnergy;
    [SerializeField] private float _currentspeed;
    [SerializeField] private DronControlButton _controlButton;
    [SerializeField] private DronePowerSupply _charging;

    private Transform _currentTransform;
    private float _currentEllipseX;
    private float _currentEllipseY;
    private bool _energyDown = false;
    private float _angleAlfaEllipseStartingPositionOld;    
    private float _energyMax;
    private float _speed;

    public event UnityAction DecreasedEnergy;

    private void Start()
    {
        _energyMax = _energy;
        _currentTransform = transform;
    }

    private void OnEnable()
    {
        _controlButton.ChargingStarted += Stop;
        _controlButton.ChargingStopped += Move;
    }

    private void OnDisable()
    {
        _controlButton.ChargingStarted -= Stop;
        _controlButton.ChargingStopped -= Move;
    }

    private void Update()
    {
        RotateInAnEllipse();
        _angleAlfaEllipseStartingPositionOld = _angleAlfaEllipseStartingPosition % (Mathf.PI * 2);
        _angleAlfaEllipseStartingPosition = _angleAlfaEllipseStartingPositionOld;
        if (Mathf.Round(_angleAlfaEllipseStartingPositionOld) == 0 && _energyDown == false)
        {
            _energy = _energy - _changeEnergy;
            DecreasedEnergy?.Invoke();
            _energyDown = true;
        }
        if (Mathf.Round(_angleAlfaEllipseStartingPositionOld) == 1)
        {
            _energyDown = false;
        }
    }

    private void Stop()
    {
        _speed = _currentspeed;
        _currentspeed = 0;
        _charging.InitEnergy(_energy, _energyMax);
    }

    private void Move()
    {
        _currentspeed = _speed;
    }

    private void RotateInAnEllipse()
    {
        _angleAlfaEllipseStartingPosition = _angleAlfaEllipseStartingPosition + (_energy * _currentspeed);
        _currentEllipseX = _parametrAEllipse * Mathf.Cos(_angleAlfaEllipseStartingPosition);
        _currentEllipseY = _parametrBEllipse * Mathf.Sin(_angleAlfaEllipseStartingPosition);
        _currentTransform.transform.position = new Vector2(_currentEllipseX, _currentEllipseY);
        transform.position = Vector2.MoveTowards(_currentTransform.transform.position, transform.position, Time.deltaTime);
    }

    public void Charge(float chargingEnergy)
    {
        _energy = chargingEnergy;
    }
}
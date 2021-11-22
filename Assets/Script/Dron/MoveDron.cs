using UnityEngine;
using UnityEngine.Events;

public class MoveDron : MonoBehaviour
{
    [SerializeField] private float _parametrAEllipse;
    [SerializeField] private float _parametrBEllipse;
    [SerializeField] private float _angleAlfaEllipseStartingPosition;
    [SerializeField] private float _energy;
    [SerializeField] private float _changeEnergy;
    [SerializeField] private float _currentspeedDron;
    [SerializeField] private DronControlButton _dronControlButton;
    [SerializeField] private ChargingDron _chargingDron;

    private Transform _oldTransform;
    private Transform _currentTransform;
    private float _currentEllipseX;
    private float _currentEllipseY;
    private bool _energyDown = false;
    private float _angleAlfaEllipseStartingPositionOld;   
    private const float _twoPI = 6.28f;
    private float _energyMax;
    private float _speedDron;

    public event UnityAction ChangeEnergyDown;

    private void Start()
    {
        _oldTransform = GetComponent<Transform>();
        _currentTransform = GetComponent<Transform>();
        _energyMax = _energy;
    }
    private void OnEnable()
    {
        _dronControlButton.ChargingDron += DronStop;
        _dronControlButton.UnChargingDron += DronMove;
    }
    private void OnDisable()
    {
        _dronControlButton.ChargingDron -= DronStop;
        _dronControlButton.UnChargingDron -= DronMove;
    }
    private void Update()
    {
        RotateInAnEllipse();
        _angleAlfaEllipseStartingPositionOld = _angleAlfaEllipseStartingPosition % _twoPI;
        _angleAlfaEllipseStartingPosition = _angleAlfaEllipseStartingPositionOld;
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
    private void DronStop()
    {
        _speedDron = _currentspeedDron;
        _currentspeedDron = 0;
        _chargingDron.DronEnergyInit(_energy, _energyMax);

    }
    private void DronMove()
    {
        _currentspeedDron = _speedDron;
    }
    private void RotateInAnEllipse()
    {
        _angleAlfaEllipseStartingPosition = _angleAlfaEllipseStartingPosition + (_energy * _currentspeedDron);
        _currentEllipseX = _parametrAEllipse * Mathf.Cos(_angleAlfaEllipseStartingPosition);
        _currentEllipseY = _parametrBEllipse * Mathf.Sin(_angleAlfaEllipseStartingPosition);
        _oldTransform.transform.position = transform.position;
        _currentTransform.transform.position = new Vector2(_currentEllipseX, _currentEllipseY);
        transform.position = Vector2.MoveTowards(_currentTransform.transform.position, _oldTransform.transform.position, Time.deltaTime);
    }
    public void DronEnergyCharging(float chargingEnergy)
    {
        _energy = chargingEnergy;
    }



}

using UnityEngine;
using UnityEngine.Events;

public class DronControlButton : MonoBehaviour
{
    public event UnityAction ChargingStarted;
    public event UnityAction ChargingStopped;

    public void TurnCharging()
    {
        ChargingStarted?.Invoke();
    }

    public void DisableCharging()
    {
        ChargingStopped?.Invoke();
    }
}
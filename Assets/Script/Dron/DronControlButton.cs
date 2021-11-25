using UnityEngine;
using UnityEngine.Events;

public class DronControlButton : MonoBehaviour
{
    public event UnityAction ChargingDron;
    public event UnityAction UnChargingDron;

    public void ButtonChargingDron()
    {
        ChargingDron?.Invoke();
    }

    public void ButtonChargingDronStop()
    {
        UnChargingDron?.Invoke();
    }
}

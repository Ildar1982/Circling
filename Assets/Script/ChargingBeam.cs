using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingBeam : MonoBehaviour
{
    [SerializeField] private Dron _target;
    [SerializeField] private ParticleSystem _particle;
    private Vector2 _startTransform;

    private void Start()
    {
        transform.position = _startTransform;
    }
    public void ButtonChargingBeam()
    {
        transform.position = _target.transform.position;
    }
    public void ButtonChargingBeamStop()
    {
        transform.position = _startTransform;
    }
}

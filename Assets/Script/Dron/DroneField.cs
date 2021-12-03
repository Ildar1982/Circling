using UnityEngine;

public class DroneField : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private DronControlButton _controlButton;
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private bool _activity = true;

    private void OnEnable()
    {
        _controlButton.ChargingStarted += Unplug;
        _controlButton.ChargingStopped += TurnOn;
    }

    private void OnDisable()
    {
        _controlButton.ChargingStarted -= Unplug;
        _controlButton.ChargingStopped -= TurnOn;
    }

    private void Unplug()
    {
        _activity = false;
        _particle.Stop();
        _spriteRenderer.enabled = false;
    }

    private void TurnOn()
    {
        _activity = true;
        _particle.Play();
        _spriteRenderer.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Monstr monstr))
        {
            if (_activity == true)
            {
                monstr.TakeDamage(_damage);
            }
        }
    }
}

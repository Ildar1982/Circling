using UnityEngine;

public class FieldDron : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private DronControlButton _dronControlButton;
    [SerializeField] private ParticleSystem Particle;
    [SerializeField] private SpriteRenderer SpriteRenderer;

    private bool _fieldDefenderActivity = true;

    private void OnEnable()
    {
        _dronControlButton.ChargingDron += DisablingField;
        _dronControlButton.UnChargingDron += EnabledField;
    }

    private void OnDisable()
    {
        _dronControlButton.ChargingDron -= DisablingField;
        _dronControlButton.UnChargingDron -= EnabledField;
    }

    private void DisablingField()
    {
        _fieldDefenderActivity = false;
        Particle.Stop();
        SpriteRenderer.enabled = false;
    }

    private void EnabledField()
    {
        _fieldDefenderActivity = true;
        Particle.Play();
        SpriteRenderer.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Monstr monstr))
        {
            if (_fieldDefenderActivity == true)
            {
                monstr.TakeDamage(_damage);
            }
        }
    }
}

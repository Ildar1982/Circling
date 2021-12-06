using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Ship : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private ParticleSystem _hit;
    [SerializeField] private ParticleSystem _explosion;   

    public event UnityAction HealthHasChanged;
    public event UnityAction Died;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        HealthHasChanged?.Invoke();
        _hit.Play();
        if (_health < 0)
        {
            _explosion.Play();
            StartCoroutine(Explosion());
        }
    }

    private IEnumerator Explosion()
    {         
        yield return new WaitForSeconds(2f);
        Died?.Invoke();
    }
}
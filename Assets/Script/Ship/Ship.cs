using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class Ship : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private ParticleSystem _hit;
    [SerializeField] private ParticleSystem _explosion;

    private WaitForSeconds waitSecondsExplosion = new WaitForSeconds(2f);

    public event UnityAction ChangeHealt;
    public event UnityAction Died;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        ChangeHealt?.Invoke();
        _hit.Play();
        if (_health < 0)
        {
            _explosion.Play();
            StartCoroutine(Explosion());
        }
    }

    private IEnumerator Explosion()
    {
        yield return waitSecondsExplosion;
        Died?.Invoke();
    }
}

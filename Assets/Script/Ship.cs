using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Ship : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private ParticleSystem _hit;
    [SerializeField] private ParticleSystem _explosion;    
    public event UnityAction Died;
    private WaitForSeconds waitSecondsDamadge = new WaitForSeconds(2f);
    public event UnityAction ChangeHealt;    
   
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
        yield return waitSecondsDamadge;
        Died?.Invoke();
    }
}

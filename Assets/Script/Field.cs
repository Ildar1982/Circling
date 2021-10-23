using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] public ParticleSystem Particle;
    [SerializeField] public SpriteRenderer SpriteRenderer;
    public bool FieldDefender = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Monstr monstr))
        {
            if (FieldDefender == true)
            {
                monstr.TakeDamage(_damage);
            }
        }
    }
}

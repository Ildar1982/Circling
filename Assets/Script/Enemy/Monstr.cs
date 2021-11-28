using System.Collections;
using UnityEngine;

public class Monstr : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private int _health;
    [SerializeField] private ParticleSystem _explosion;

    private Ship _target;
    private Score _score;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
    }

    public void Init(Ship target, Score score)
    {
        _target = target;
        _score = score;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ship ship))
        {
            ship.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            _explosion.Play();
            StartCoroutine(DelayDestruction());
            _score.IncreseScore();
        }
    }

    private IEnumerator DelayDestruction()
    {
        WaitForSeconds waitSecondsDamadge = new WaitForSeconds(0.2f);

        yield return waitSecondsDamadge;
        Destroy(gameObject);
    }
}

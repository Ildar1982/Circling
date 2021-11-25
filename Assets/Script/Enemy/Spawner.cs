using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Monstr _monstr;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Ship _target;
    [SerializeField] private AccrualAndWithdrawalPoints _score;

    private WaitForSeconds waitForTwoSeconds = new WaitForSeconds(1.5f);
    private int numberPoints;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {

            numberPoints = Random.Range(0, _spawnPoints.Length);
            Monstr monstr = Instantiate(_monstr, _spawnPoints[numberPoints]).GetComponent<Monstr>();
            monstr.Init(_target, _score);
            yield return waitForTwoSeconds;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class HealtShip : MonoBehaviour
{
    [SerializeField] private Ship _ship;
    [SerializeField] private Image _image;

    private const float _degreeReductionLife = 0.16f;

    private void OnEnable()
    {
        _ship.HealthHasChanged += ChangeHealt;
    }

    private void OnDisable()
    {
        _ship.HealthHasChanged -= ChangeHealt;
    }

    private void ChangeHealt()
    {
        _image.fillAmount = _image.fillAmount - _degreeReductionLife;
    }
}

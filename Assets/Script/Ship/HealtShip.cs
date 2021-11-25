using UnityEngine;
using UnityEngine.UI;

public class HealtShip : MonoBehaviour
{
    [SerializeField] private Ship _ship;
    [SerializeField] private Image _image;

    private const float _degreeReductionLifeShip = 0.16f;

    private void OnEnable()
    {
        _ship.ChangeHealt += ChangeHealt;
    }

    private void OnDisable()
    {
        _ship.ChangeHealt -= ChangeHealt;
    }

    private void ChangeHealt()
    {
        _image.fillAmount = _image.fillAmount - _degreeReductionLifeShip;
    }
}

using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;

[RequireComponent(typeof(CanvasGroup))]
public class Menu : MonoBehaviour
{
    [SerializeField] private Ship _ship;
    [SerializeField] private DroneMovement _dron;
    [SerializeField] private Button _energyButton;

    private CanvasGroup _canvasGroup;
    private bool _shipDied = false;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
    }

    private void OnEnable()
    {
        _ship.Died += Enable;
        _ship.Died += RegisterShipDied;
    }

    private void OnDisable()
    {
        _ship.Died -= Enable;
        _ship.Died -= RegisterShipDied;
    }

    public void Enable()
    {
        _canvasGroup.alpha = 1;
        Time.timeScale = 0;
        _dron.gameObject.SetActive(false);
        _energyButton.gameObject.SetActive(false);
    }

    private void RegisterShipDied()
    {
        _shipDied = true;
    }

    public void Disable()
    {
        if (_shipDied == false)
        {
            _canvasGroup.alpha = 0;
            Time.timeScale = 1;
            _dron.gameObject.SetActive(true);
            _energyButton.gameObject.SetActive(true);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SampleScene.Load();
    }
}

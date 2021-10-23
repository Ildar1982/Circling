using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]

public class Menu : MonoBehaviour
{
    [SerializeField] private Ship _ship;
    [SerializeField] private Dron _dron;
    [SerializeField] private Button _energy_button;
    private CanvasGroup _canvasGroup;
    private bool _shipDied = false;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
    }
    private void OnEnable()
    {
        _ship.Died += DiedOrButtonExit;
        _ship.Died += RegisterShipDied;
    }
    private void OnDisable()
    {
        _ship.Died -= DiedOrButtonExit;
        _ship.Died -= RegisterShipDied;
    }
    public void DiedOrButtonExit()
    {
        _canvasGroup.alpha = 1;
        Time.timeScale = 0;
        _dron.gameObject.SetActive(false);
        _energy_button.gameObject.SetActive(false);
    }
    private void RegisterShipDied()
    {
        _shipDied = true;
    }
    public void CloseButton()
    {
        if (_shipDied == false)
        {
            _canvasGroup.alpha = 0;
            Time.timeScale = 1;
            _dron.gameObject.SetActive(true);
            _energy_button.gameObject.SetActive(true);
        }
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}

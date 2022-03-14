using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pointText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] GameObject gameoverUI;
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject pauseUIGameObject;

    private void Start()
    {
    }
    private void Update()
    {
        if (GameManager.Instance.gameOver)
            return;
        GameManager.Instance.UpdateText(pointText, livesText);
    }


    // When The UI Pause Button Is Pressed
    public void PauseButtonPressed()
    {
        if (GameManager.Instance.isPaused)
        {
            GameManager.Instance.isPaused = false;
            GameManager.Instance.SetTimeScale(1);
            PauseUI(false);
        }
        else if (!GameManager.Instance.isPaused)
        {
            GameManager.Instance.isPaused = true;
            GameManager.Instance.SetTimeScale(0);
            PauseUI(true);
        }
    }

    public void PauseUI(bool value)
    {
        pauseUIGameObject.SetActive(value);
        pauseUI.SetActive(value);
    }

    public void GameOver(bool value)
    {
        gameoverUI.SetActive(value);
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return instance; } }
    private static GameManager instance;
    private UIManager uiManager;

    [SerializeField] int point;
    [SerializeField] int lives = 3;

    public bool gameOver;
    public bool isPaused;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        isPaused = false;
        SetTimeScale(1);
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Update()
    {
        gameOver = lives <= 0;
        if(lives <= 0)
            lives = 0;
        uiManager.GameOver(gameOver);
        PauseGame();
    }

    public void PauseGame()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            if(isPaused)
            {
                isPaused = false;
                SetTimeScale(1);
                uiManager.PauseUI(false);
            }
            else if(!isPaused)
            {
                isPaused = true;
                SetTimeScale(0);
                uiManager.PauseUI(true);
            }
        }
    }

    public void AddPoint(int _point)
    {
        point += _point;
    }
    public void RemovePoint(int _point)
    {
        if (point > 0)
            point -= _point;
        lives--;
    }

    public void UpdateText(TextMeshProUGUI pointText, TextMeshProUGUI livesText)
    {
        pointText.text = $"POINT: {point}";
        livesText.text = $"LIVES: {lives}";
    }

    public void SetTimeScale(float value)
    {
        Time.timeScale = value;
    }
}

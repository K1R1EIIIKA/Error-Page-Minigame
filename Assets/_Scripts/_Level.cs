using System;
using TMPro;
using UnityEngine;

public class _Level : MonoBehaviour
{
    [Header("Characteristics")] 
    public int maxHealth = 3;
    public int health;
    public int points;
    public float spawnRate = 1f;

    [Header("Objects")]
    public TMP_Text healthText;
    public TMP_Text pointsText;
    public TMP_Text endGameText;
    
    public ButtonClick button;
    public GameObject startgameCanvas;
    public GameObject endGameCanvas;

    [NonSerialized] public bool IsGameStart;

    private void Start()
    {
        health = maxHealth;
        startgameCanvas.SetActive(true);
    }

    private void Update()
    {
        healthText.text = "Жизней: " + health;
        pointsText.text = "Очков: " + points;

        // Старт игры
        if (button.IsStartClicked)
        {
            startgameCanvas.SetActive(false);
            IsGameStart = true;
        }
        
        // Смерть
        if (health == 0)
        {
            IsGameStart = false;
            endGameCanvas.SetActive(true);
            endGameText.text = "Вы проиграли.\n" +
                               "Вы набрали " + points + " очков.\n\n" +
                               "Пока мы еще не исправили проблему, желаете сыграть снова?";
        }

        // Рестарт после смерти
        if (button.IsEndRestartClicked)
        {
            endGameCanvas.SetActive(false);
            health = maxHealth;
            points = 0;
            
            Restart();
        }

        // Рестарт во время игры
        if (button.IsRestartClicked)
        {
            IsGameStart = false;
            health = maxHealth;
            points = 0;
            
            Invoke(nameof(Restart), 0.5f);
        }
        
        button.IsRestartClicked = false;
        button.IsStartClicked = false;
        button.IsEndRestartClicked = false;
    }
    
    private void Restart()
    {
        IsGameStart = true;
    }
}

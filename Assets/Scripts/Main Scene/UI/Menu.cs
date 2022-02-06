using System.Collections;
using System.Collections.Generic;
using Audio;
using Game;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject gamePanel;
    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public Text gameOverScoreText;
    public Text gameOverTotalScoreText;
    public Text gameScoreText;
    public Text gameScoreComboText;

    public void OnPausePanelButton()
    {
        if (GameManager.instance.isGame)
        {
            gamePanel.SetActive(false);
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void OnContinueButton()
    {
        if (GameManager.instance.isGame)
        {
            gamePanel.SetActive(true);
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void OnClickRestartGameButton()
    {
        
        gameOverPanel.SetActive(false);
        gamePanel.SetActive(true);
        GameManager.instance.RestartGame();
        
    }
    public void MusicControl()
    {
        foreach (var s in AudioManager.Instance.sounds)
        {
            s.source.enabled = !s.source.enabled;
        }
    }
  
    
}

using System;
using Audio;
using Game;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Main_Scene.UI
{
    public class Menu : MonoBehaviour
    {
        public GameObject gamePanel;
        public GameObject gameOverPanel;
        public GameObject pausePanel;
        public Text gameOverScoreText;
        public Text gameOverTotalScoreText;
        public Text gameScoreText;
        public Text gameScoreComboText;
        public TMP_Text allScoreText;

        private void Start()
        {
            GameManager.Instance.OnFinishGame += OnFinishGame;
        }


        private void OnFinishGame()
        {
            gamePanel.SetActive(false);
            gameOverPanel.SetActive(true);
        }

        public void OnPausePanelButton()
        {
            if (GameManager.Instance.isGame)
            {
                gamePanel.SetActive(false);
                pausePanel.SetActive(true);
                Time.timeScale = 0;
            }
        }

        public void OnContinueButton()
        {
            if (GameManager.Instance.isGame)
            {
                gamePanel.SetActive(true);
                pausePanel.SetActive(false);
                Time.timeScale = 1;
            }
        }

        public void OnClickBackToMenuSceneButton()
        {
            Physics.gravity /= GamePhysics.GetGravityModifier();
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
        public void OnClickRestartGameButton()
        {
            gameScoreComboText.gameObject.SetActive(false);
            gamePanel.SetActive(true);
            gameOverPanel.SetActive(false);
            GameManager.Instance.RestartGame();

        }

        public void MusicControl()
        {
            foreach (var s in AudioManager.Instance.sounds)
            {
                s.source.enabled = !s.source.enabled;
            }
        }


    }
}
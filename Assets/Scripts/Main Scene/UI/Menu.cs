using Audio;
using Game;
using TMPro;
using UnityEngine;
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

        public void OnClickRestartGameButton()
        {
            gameScoreComboText.gameObject.SetActive(false);
            gamePanel.SetActive(true);
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
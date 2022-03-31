using System.Collections;
using Audio;
using UnityEngine;
using Clocks;
using Main_Scene.Boosters;
using Main_Scene.Score;
using Main_Scene.UI;
using Main_Scene.Character;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Game
{
    public static class GamePhysics
    {
        private const float GravityModifier = 10;

        public static float GetGravityModifier()
        {
            return GravityModifier;
        }
    }

    public class GameManager : Singleton<GameManager>
    {
        public PlayerMovement playerMovement;
        public ClockController clockController;
        public Menu menu;
        public FadingPanel gameOverPanel;
        public ParticleSystem particle;
        private bool _isParticleStopped;
        public UnityEvent onFinishTheGame;
        public bool isGame;
        private void Start()
        {
            Physics.gravity *= GamePhysics.GetGravityModifier();
            GetAndSetAllScoreToText();
        }

        private void GetAndSetAllScoreToText()
        {
            if (menu.allScoreText.text.Length == 0)
            {
                menu.allScoreText.text = ScoreManager.Instance.GetAllScore().ToString();
            }
        }
        public void RestartGame()
        {
            isGame = true;
            if (clockController == null) return;
            clockController.SetClocksSpeedDefault();
            clockController.SetClocksRotationDefault();
            if (playerMovement != null) playerMovement.ResetPlayerPhysic();
            MaterialManager.Instance.Reset();
            gameOverPanel.FadeOut(0.5f);
            menu.allScoreText.text = ScoreManager.Instance.GetAllScore().ToString();
            ScoreManager.Instance.ResetText();
        }
        public void FinishGame()
        {
            if (!isGame) return;
            isGame = false;
            onFinishTheGame.Invoke();
            menu.gamePanel.SetActive(false);
            playerMovement.ResetPlayerPhysic();
            ScoreManager.Instance.SaveMoney("money");
            SetScoreToText(ScoreManager.Instance.score,ScoreManager.Instance.GetAllScore());
            gameOverPanel.FadeIn(1f);
            ScoreManager.Instance.ResetText();
            BoosterManager.Instance.SetDefaultPlayerProperties();
        }
        public IEnumerator StopParticle()
        {
            if(_isParticleStopped) yield break;
        
            _isParticleStopped = true;
        
            yield return new WaitForSeconds(0.4f);
        
            particle.Stop();
        
            _isParticleStopped = false;
        }
        public void PlayParticle()
        {
            particle.Play();
        }

        public void SetScoreToTextRuntime(int score)
        {
            menu.gameScoreText.text = score.ToString();
        }

        private void SetScoreToText(int score,int totalScore)
        {
            menu.gameOverScoreText.text = $" YOUR SCORE :     {score}";
            menu.gameOverTotalScoreText.text = $" TOTAL SCORE  :     {totalScore}";
        }

    }
}

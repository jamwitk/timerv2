using System.Collections;
using Audio;
using UnityEngine;
using Clocks;
using Main_Scene;
using Main_Scene.Score;
using Main_Scene.UI;
using Main_Scene.Character;

namespace Game
{
    public class GameManager : Singleton<GameManager>
    {
        public Player player;
        public ClockController clockController;
        public Menu menu;
        public FadingPanel gameOverPanel;
        public MaterialManager materialManager;
        public ParticleSystem particle;
        private bool _isParticleStopped, _isWorking;

        public bool isGame;
        private const float GravityModifier = 10;
        
        private void Start()
        {
            Physics.gravity *= GravityModifier;
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
            if (player != null) player.Reset();
            if (materialManager != null) materialManager.Reset();
            gameOverPanel.FadeOut(0.5f);
            menu.allScoreText.text = ScoreManager.Instance.GetAllScore().ToString();
            ScoreManager.Instance.ResetText();
        }
        public void FinishGame()
        {
            if (!isGame) return;
            isGame = false;
            CameraController.Instance.Shake();
            AudioManager.Instance.Play("Punch");
            menu.gamePanel.SetActive(false);
            player.Reset();
            ScoreManager.Instance.SaveMoney("money");
            SetScoreToText(ScoreManager.Instance.score,ScoreManager.Instance.GetAllScore());
            gameOverPanel.FadeIn(1f);
            //StartCoroutine(DelayGameOverPanel());
            ScoreManager.Instance.ResetText();
        }

       
        
        private IEnumerator DelayGameOverPanel()
        {
            if(_isWorking) yield break;
            _isWorking = true;

            yield return new WaitForSecondsRealtime(0.75f);

            menu.gameOverPanel.SetActive(true);
            _isWorking = false;
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

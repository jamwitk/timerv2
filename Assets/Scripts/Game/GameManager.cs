using System.Collections;
using Audio;
using UnityEngine;
using Clocks;
using Score;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        //Scripts
        public Player.Player player;
        public CameraShaking cameraShaking;
        public ClockController clockController;
        public Menu menu;

        public MaterialManager materialManager;

        public ScoreManager scoreManager;
        //Objects
        public ParticleSystem particle;
        //Inputs
        [HideInInspector] public bool isAndroid , isWindows;
        private bool isParticleStopped, isWorking;

        public bool isGame;
        //Instance
        public static GameManager instance;
        private const float GravityModifier = 10;

        private void Awake()
        {
            #region Singleton
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        

            #endregion

            #region ApplicationSettings

            Physics.gravity *= GravityModifier;
            Application.targetFrameRate = 60;
            

            #endregion
        }
        public void RestartGame()
        {
            isGame = true;
            if (clockController == null) return;
            clockController.SetClocksSpeedDefault();
            clockController.SetClocksRotationDefault();
            if (player != null) player.Reset();
            if (materialManager != null) materialManager.Reset();
            if (scoreManager != null) scoreManager.ResetText();
        }
        public void FinishGame()
        {
            if (!isGame) return;
            isGame = false;
            cameraShaking.CameraShake();
            AudioManager.Instance.Play("Punch");
            menu.gamePanel.SetActive(false);
            player.Reset();
            StartCoroutine(GameManager.instance.DelayGameOverPanel());
            
        }
    
        public IEnumerator DelayGameOverPanel()
        {
            if(isWorking) yield break;
            isWorking = true;

            yield return new WaitForSecondsRealtime(0.75f);

            menu.gameOverPanel.SetActive(true);
            isWorking = false;
        }
        public IEnumerator StopParticle()
        {
            if(isParticleStopped) yield break;
        
            isParticleStopped = true;
        
            yield return new WaitForSeconds(0.4f);
        
            particle.Stop();
        
            isParticleStopped = false;
        }
        public void PlayParticle()
        {
            particle.Play();
        }

        public void SetScoreToTextRuntime(int score)
        {
            menu.gameScoreText.text = score.ToString();
        }
        public void SetScoreToText(int score,int totalScore)
        {
            menu.gameOverScoreText.text = $" YOUR SCORE :     {score}";
            menu.gameOverTotalScoreText.text = $" TOTAL SCORE  :     {totalScore}";
        }

    }
}

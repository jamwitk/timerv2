using System.Collections;
using UnityEngine;
using Clocks;
using Main_Scene.Score;
using Main_Scene.UI;
using Main_Scene.Character;
using UnityEngine.Events;

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
        public ParticleSystem particle;
        private bool _isParticleStopped;
        public bool isGame;

        public event UnityAction OnFinishGame;
        public event UnityAction OnRestartGame;
       
        private void Start()
        {
            Physics.gravity *= GamePhysics.GetGravityModifier();
            GetAndSetAllScoreToText();
        }
        private void GetAndSetAllScoreToText()
        {
            if (menu.allScoreText.text.Length == 0)
            {
                menu.allScoreText.text = ScoreManager.GetAllScore().ToString();
            }
        }
        public void RestartGame()
        {
            isGame = true;
            OnRestartGame?.Invoke();
            menu.allScoreText.text = ScoreManager.GetAllScore().ToString();
        }
        public void FinishGame()
        {
            isGame = false;
            OnFinishGame?.Invoke();
            SetScoreToText(ScoreManager.Instance.score,ScoreManager.GetAllScore());
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

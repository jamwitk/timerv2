using System;
using Clocks;
using DG.Tweening;
using Main_Scene;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class ScoreManager : Singleton<ScoreManager>
    {

        [SerializeField] private ClockController clockController;
        [SerializeField] private int scorePoint = 46;
        public GameObject scoreComboObject;
        public Text scoreTxt,scoreComboTxt;
        [NonSerialized] public int score;
        [NonSerialized] private int _scoreIncrease = 1;
        [NonSerialized] public int ScoreCombo;
        [NonSerialized] private int _score;
        private void Start()
        {
            DOTween.Init();
            GameManager.Instance.OnFinishGame += OnFinishGame;
            GameManager.Instance.OnFinishGame += ResetText;
        }

        private void OnDestroy()
        {
            GameManager.Instance.OnFinishGame -= OnFinishGame;
            GameManager.Instance.OnFinishGame -= ResetText; 
        }

        private void OnFinishGame()
        {
            SaveMoney("money");
        }

        public void CalculateScore()
        {
            score += scorePoint * _scoreIncrease; 
            _score += (scorePoint * _scoreIncrease);
            GameManager.Instance.SetScoreToTextRuntime(score);
            if (ScoreCombo != 4) return;
            _scoreIncrease += 1; 
            ScoreCombo = 0; 
            scoreComboTxt.text = "COMBO "+ _scoreIncrease + "X"; 
            scoreComboObject.SetActive(true); 
            PunchText(scoreComboObject.transform);
        }

       

        public void SaveMoney(string key)
        {
            FileManager.Instance.SaveData(key,GetAllScore()+score);
        }

       
        public static int GetAllScore()
        {
            return FileManager.Instance.GetIntData("money");
        }
        private void Update()
        {
            if (_score < 1000) return;
            _score -= 1000;
            clockController.ReverseAndAddSpeedClocksDirection();
        }

        public void ResetText()
        {
            
            score = 0;
            _score = 0;
            _scoreIncrease = 1;
            ScoreCombo = 0;
            scoreTxt.text = "" + score;
        }

        private void PunchText(Transform comboText)
        {
            comboText.DOPunchScale(transform.localScale, 0.7f);
        }
        
    }

    
}

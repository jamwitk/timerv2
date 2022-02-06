using System;
using Clocks;
using DG.Tweening;
using Game;
using UnityEngine;
using UnityEngine.UI;

namespace Score
{
    public class ScoreManager : MonoBehaviour
    {
        public const string ScoreKey = "scoreKey";

        [SerializeField] private ClockController clockController;
        [SerializeField] private int scorePoint = 46;
        public GameObject scoreComboObject;
        public Text scoreTxt,scoreComboTxt,totalScoreText;
        [NonSerialized] public int Score;
        [NonSerialized] private int _scoreIncrease = 1;
        [NonSerialized] public int ScoreCombo;
        [NonSerialized] private int _score;
        private void Start()
        {
            DOTween.Init();
        }
        public void ScoreCalculation()
        {
            Score += scorePoint * _scoreIncrease; 
            _score += (scorePoint * _scoreIncrease);
            GameManager.instance.SetScoreToTextRuntime(Score);
            if (ScoreCombo != 4) return;
            _scoreIncrease += 1; 
            ScoreCombo = 0; 
            scoreComboTxt.text = "COMBO "+ _scoreIncrease + "X"; 
            scoreComboObject.SetActive(true); 
            PunchText(scoreComboObject.transform);
        }

        public void AddToLeaderBoard()
        {
            
        }

        private static void SaveScore(string key,int score)
        {
            PlayerPrefs.SetInt(key,score);
            PlayerPrefs.Save();
        }

        public void SetTotalScoreTextBox(string key,Text totalScoreTextBox)
        {
            totalScoreText.text = (GetScore(key) + Score).ToString();
        }
        private static int GetScore(string key)
        {
            return PlayerPrefs.GetInt(key, 0);
        }
        private void Update()
        {
            if (_score < 1000) return;
            _score -= 1000;
            clockController.ReverseAndAddSpeedClocksDirection();
        }

        public void ResetText()
        {
            SaveScore(ScoreKey, Score);
            Score = 0;
            _score = 0;
            _scoreIncrease = 1;
            ScoreCombo = 0;
            scoreComboObject.SetActive(false);
            scoreTxt.text = "" + Score;
            
        }

        private void PunchText(Transform comboText)
        {
            comboText.DOPunchScale(transform.localScale, 0.7f);
        }
    }
}

using System;
using Clock;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Score
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private int scorePoint = 46;
        public GameObject scoreComboObject;
        public Text scoreTxt,scoreComboTxt;
        [NonSerialized] public int Score;
        [NonSerialized] private int _scoreIncrease = 1;
        [NonSerialized] public int ScoreCombo;
        [NonSerialized] private int _score;
        public RotateClock[] clocks;
        private void Start()
        {
            DOTween.Init();
        }

        public void ScoreCalculation()
        {
            Score += scorePoint * _scoreIncrease; 
            _score += (scorePoint * _scoreIncrease);
            scoreTxt.text =""+Score;

            if (ScoreCombo != 4) return;
        
            _scoreIncrease += 1; // plus increase
            ScoreCombo = 0; // Setting combo zero
            scoreComboTxt.text = "COMBO "+ _scoreIncrease + "X"; // Write combo number on TextBox
            scoreComboObject.SetActive(true); // Show on screen
            PunchText(scoreComboObject.transform); // Animate

        }

        private void Update()
        {
            //Check for reach 1000 , 20000, 3000 etc
            if (_score < 1000) return;
            _score -= 1000;
            clocks[0].ReverseClocks(); // reverse for Akrep
            clocks[1].ReverseClocks(); // reverse for Yelkovan
        }

        public void ResetText()
        {
            Score = 0;
            _score = 0;
            _scoreIncrease = 1;
            ScoreCombo = 0;
            scoreComboObject.SetActive(false);
            scoreTxt.text = "" + Score;
        }

        private void PunchText(Transform comboText)
        {
            //Combo animation
            comboText.DOPunchScale(transform.localScale, 0.7f);
        }
    }
}

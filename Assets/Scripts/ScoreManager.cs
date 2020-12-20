using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject ScoreComboObject;
    public Text scoreTxt,scoreComboTxt;
    [NonSerialized] public int Score, ScoreIncrease = 1,ScoreCombo;
    public Text gameOverText;
    private void Start()
    {
        DOTween.Init();

    }

    public void ScoreCalculation()
    {
        Score = Score + (46*ScoreIncrease);
        scoreTxt.text =""+Score;
        
        if (ScoreCombo == 4)
        {
            ScoreIncrease = ScoreIncrease + 1; // plus increase
            ScoreCombo = 0; // Setting combo zero
            scoreComboTxt.text = "COMBO "+ ScoreIncrease + "X"; // Write combo number on TextBox
            ScoreComboObject.SetActive(true); // Show on screen
            PunchText(ScoreComboObject.transform); // Animate
        }
        
    }

    public void ResetText()
    {
        Score = 0;
        ScoreIncrease = 1;
        ScoreCombo = 0;
        ScoreComboObject.SetActive(false);
        scoreTxt.text = "" + Score;
    }
 
    void PunchText(Transform comboText)
    {
        //Combo animation
       comboText.DOPunchScale(transform.localScale, 0.7f);
    }
}

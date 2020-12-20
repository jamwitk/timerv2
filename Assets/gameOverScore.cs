using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class gameOverScore : MonoBehaviour
{
    public Text GameOverScoretext;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //continue game
        }
    }

    public void SetGameOverScore()
    {
        GameOverScoretext.text = FindObjectOfType<ScoreManager>().Score.ToString(); // ScoreManager objesini bulup oradaki Score değişkenine ulaşır
    }
}

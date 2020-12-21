using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class gameOverScore : MonoBehaviour
{
    public Text gameOverScoretext;
    public GameObject[] clocks;
    public ButtonScript gameManager;
    public Player player;
    public ScoreManager scoreManager;
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        { 
            //continue game
            clocks[0].transform.rotation = Quaternion.Euler(Vector3.zero); // Reset rotation yelkovan
            clocks[1].transform.rotation = Quaternion.Euler(Vector3.zero); // Reset rotation akrep
            clocks[0].GetComponent<RotateClock>().donmeHizi = 60;  // Give rotate speed to rotation
            clocks[1].GetComponent<RotateClock>().donmeHizi = 60;  // Give rotate speed to rotation
            gameManager.RandomizePlanes(); // Setting random color to all plane
            gameManager.SettingDafueltMaterials(); //Gets new default material valıe
            player.RestartCharacter(); // Start character move and jump
            gameManager._ChangeToCustom(); // Select one random red material
            scoreManager.ResetText(); // reset score
            gameObject.SetActive(false); // Close GAME over panel
            
        }
    }

    public void SetGameOverScore()
    {
        gameOverScoretext.text = FindObjectOfType<ScoreManager>().Score.ToString(); // ScoreManager objesini bulup oradaki Score değişkenine ulaşır
    }
}

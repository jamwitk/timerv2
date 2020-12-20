using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Random = System.Random;

public class ButtonScript : MonoBehaviour
{
    public ScoreManager scoreManager;
    public GameObject gameOverPanel;
    private Player _player;
    private RotateClock _rotateClock;
    private ChangeMaterial _changeMaterial;
    private Random _random;
    public GameObject[] planes;
    [NonSerialized]public int random;

    private void Start()
    {
        _random = new Random();   
        _player = GameObject.Find("Cube").GetComponent<Player>();
        _ChangeToCustom();
    }
    public void RandomizePlanes()
    {
        for (int i = 0; i < 12; i++)
        {
            planes[i].GetComponent<ChangeMaterial>().RandomMaterial();
        }
    }

    public int RandomCustomIndex()
    {
        return _random.Next(11);
    }

    public void RetryGame()
    {
        //Setting Akrep And Yelkovan into (0,0,0) rotation
        _player.clocks[0].transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
        _player.clocks[1].transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
        //Giving speed for rotate Akrep And Yelkovan
        _player.clocks[0].GetComponent<RotateClock>().donmeHizi = 60;
        _player.clocks[1].GetComponent<RotateClock>().donmeHizi = 60;
        //Create new random material into planes
        RandomizePlanes();
        //Set default material
        SettingDafueltMaterials();
        //Give speed, jumpForce  
        _player.RestartCharacter();
        //Setting random material while clicking RETRY button 
        _ChangeToCustom2();
        //Setting character to default position
        _player.transform.position = new Vector3(0,1,-8);
        
        scoreManager.ResetText(); // Reset Score
        gameOverPanel.SetActive(false); //Close RETRY button from scene
        

    }
    public void SettingDafueltMaterials()
    {
        for (int i = 0; i < planes.Length; i++)
        {
           
                planes[i].GetComponent<ChangeMaterial>().GetDefaultMaterial();
            
        }
    }
    public void _ChangeToCustom()
    {
       
        if (_player.isJumpedToPlane)
        {
            random = RandomCustomIndex();
            planes[random].GetComponent<ChangeMaterial>().ChangeToCustom();
            _player.isJumpedToPlane = false;
        }
        
    }
    public void _ChangeToCustom2()
    {

        if (_player.isJumpedToPlane)
        {
            random = RandomCustomIndex();
            planes[random].GetComponent<ChangeMaterial>().ChangeToCustom();
            _player.isJumpedToPlane = false;
        }

    }


}

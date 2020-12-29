using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Scripts
    public Player player;
    public CameraShaking cameraShaking;
    
    //Objects
    public GameObject buttonPause;
    public ParticleSystem particle;
    public GameObject joystick;

    public GameObject buttonSpace;
    public GameObject pausePanel;
    public GameObject goverPanel;

    public RotateClock[] clocks; 
    //Inputs
    public bool isAndroid;

    public bool isWindows;

    //Instance
    public static GameManager instance;

    private void Awake()
    {
        #region singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        

        #endregion

        #region PlatformDetection
        
#if UNITY_ANDROID
    isAndroid = true;
    buttonPause.SetActive(true);
    joystick.SetActive(true);
    buttonSpace.SetActive(true);
#elif UNITY_STANDALONE_WIN
        isWindows = true;
#endif
        

        #endregion

        
    }

    private void Update()
    {
        if (!Input.GetButtonDown("Cancel")) return;
        PauseGame();
        pausePanel.SetActive(true);
    }

    public void PauseGame()
    {
        //Stops every objects who has action on scene
        if (isAndroid)
        {
            buttonPause.SetActive(false);
            joystick.SetActive(false);
            buttonSpace.SetActive(false);
        }
        
        clocks[0].rotateSpeed = 0;
        clocks[1].rotateSpeed = 0;

        player.moveSpeed = 0;
        player.jumpForce = 0;
        player.isJumpedToPlane = true;
    }
    
    public void RestartGame()
    {
        if (isAndroid)
        {
            buttonPause.SetActive(true);
            joystick.SetActive(true);
            buttonSpace.SetActive(true);
        }

        clocks[0].rotateSpeed = clocks[0].speed;
        clocks[1].rotateSpeed = clocks[1].speed;

        player.moveSpeed = player._moveSpeed;
        player.jumpForce = 20;
        player.isGrounded = true;
        player.transform.position = new Vector3(0,1,-8);
        
        goverPanel.SetActive(false);
    }

    public void ContinueGame()
    {
        if (isAndroid)
        {
            buttonPause.SetActive(true);
            joystick.SetActive(true);
            buttonPause.SetActive(true);
        }
        
        clocks[0].rotateSpeed = clocks[0].speed;
        clocks[1].rotateSpeed = clocks[1].speed;

        player.moveSpeed = player._moveSpeed;
        player.jumpForce = 20;
        player.isGrounded = true;
        
        pausePanel.SetActive(false);
    }

    public void Die()
    {
        cameraShaking.CameraShake();
        
        if (isAndroid)
        {
            buttonPause.SetActive(false);
            joystick.SetActive(false);
            buttonSpace.SetActive(false);
        }
        
        clocks[0].rotateSpeed = 0;
        clocks[1].rotateSpeed = 0;

        player.moveSpeed = 0;
        player.jumpForce = 0;
        player.isJumpedToPlane = true;
        player.transform.position = new Vector3(0,1,-8);
        
        goverPanel.SetActive(true);
    }
    public void StopParticle()
    {
        particle.Stop();
    }

    public void PlayParticle()
    {
        particle.Play();
    }

    public void OpenGameOverPanel()
    {
        goverPanel.SetActive(true);
    }
    
}

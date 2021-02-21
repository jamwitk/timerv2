﻿using System.Collections;
using UnityEngine;
using Clock;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        //Scripts
        public Player.Player player;
        public CameraShaking cameraShaking;
    
        //Objects
        public ParticleSystem particle;
        public GameObject joystick;
        public GameObject buttonSpace;
        public GameObject pausePanel;
        public GameObject goverPanel;
        public RotateClock[] clocks; 
        //Inputs
        [HideInInspector] public bool isAndroid , isWindows;
        private bool isParticleStopped, isWorking;
     
        //Instance
        public static GameManager instance;

        private void Awake()
        {
            #region singleton
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        

            #endregion

            #region PlatformDetection
            Application.targetFrameRate = 60;
#if UNITY_ANDROID
            isAndroid = true;
            joystick.SetActive(true);
            buttonSpace.SetActive(true);
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
                joystick.SetActive(false);
                buttonSpace.SetActive(false); 
            }
        
            clocks[0].rotateSpeed = 0;
            clocks[1].rotateSpeed = 0;

            player.moveSpeed = 0;
            player.jumpForce = 0;
            player.isJumpedToPlane = true;
            player.isGrounded = true;
            player.isCrunched = false;
        }
    
        public void RestartGame()
        {
            if (isAndroid)
            {
                joystick.SetActive(true);
                buttonSpace.SetActive(true);
            }

            clocks[0].rotateSpeed = clocks[0].speed;
            clocks[1].rotateSpeed = clocks[1].speed;

            player.moveSpeed = player.privateMoveSpeed;
            player.jumpForce = 20;
            player.isGrounded = true;
            player.transform.position = new Vector3(0,1,-8);

            goverPanel.SetActive(false);
        }

        public void ShowAd()
        {
            //Rewarded ads 
        }
        public void ContinueGame()
        {
            if (isAndroid)
            {
                buttonSpace.SetActive(true);
                joystick.SetActive(true);
            }
        
            clocks[0].rotateSpeed = clocks[0].speed;
            clocks[1].rotateSpeed = clocks[1].speed;

            player.moveSpeed = player.privateMoveSpeed;
            player.jumpForce = 20;
            player.isGrounded = true;
        
            pausePanel.SetActive(false);
        }

        public void Die()
        {
            cameraShaking.CameraShake();
        
            if (isAndroid)
            {
                joystick.SetActive(false);
                buttonSpace.SetActive(false);
            }
        
            clocks[0].rotateSpeed = 0;
            clocks[1].rotateSpeed = 0;

            player.moveSpeed = 0;
            player.jumpForce = 0;
            
            
            
            

            //Resetting
            player.isJumpedToPlane = true;
            player.transform.position = new Vector3(0,1,-8);
        
        
        
            goverPanel.SetActive(true);
        }
    
        public IEnumerator DelayGameOverPanel()
        {
            if(isWorking) yield break;
            isWorking = true;

            yield return new WaitForSeconds(0.75f);

            goverPanel.SetActive(true);

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

    }
}
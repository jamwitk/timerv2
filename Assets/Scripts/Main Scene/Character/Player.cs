﻿using Game;
using UnityEngine;

namespace Main_Scene.Character
{
    //[RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour
    {
        public Joystick joystick;
    
        public float moveSpeed;
        public float jumpForce;
    
        public bool isGrounded;
        public bool isCrunched;
        public float privateMoveSpeed;
        
        void Start()
        {
            privateMoveSpeed = moveSpeed;
        }
        private void Update()
        {
            if(!GameManager.Instance.isGame) return;
            //Move();
            if(transform.position.y <= -1)
            {
                //GameManager.instance.FinishGame();
            }
        }
        private void FixedUpdate()
        {
            if (!GameManager.Instance.isGame) return;
            if (isGrounded && !isCrunched) isGrounded = false;
        }
        

        public void Reset()
        {
            moveSpeed = privateMoveSpeed;
            jumpForce = 20;
            isGrounded = true;
            transform.position = new Vector3(0,1,-8);
        }
    }
}

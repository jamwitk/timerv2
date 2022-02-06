using System.Collections;
using Game;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour
    {
        public Joystick joystick;
    
        public float moveSpeed;
        public float jumpForce;
    
        public bool isGrounded;
        public bool isCrunched;
        public bool isJumpedToPlane = true;
        public float privateMoveSpeed;
        
        private Rigidbody _rigidbody;
        void Start()
        {
            privateMoveSpeed = moveSpeed;
            _rigidbody = GetComponent<Rigidbody>();
        }
        private void Update()
        {
            if(!GameManager.instance.isGame) return;
            Move();
            if(transform.position.y <= -1)
            {
                GameManager.instance.FinishGame();
            }
        }
        private void FixedUpdate()
        {
            if (!GameManager.instance.isGame) return;
            if (!isGrounded || isCrunched) return;
            isGrounded = false;
            _rigidbody.AddForce(Vector3.up * jumpForce,ForceMode.VelocityChange);
        }

        public void SpaceDown()
        {
            moveSpeed = 0;
            isCrunched = true;
        }

        public void SpaceUp()
        {
            moveSpeed = privateMoveSpeed;
            isCrunched = false;
        }
        
        private void Move()
        {
            transform.Translate(joystick.Horizontal * moveSpeed * Time.deltaTime * moveSpeed, 0f,
                    joystick.Vertical * moveSpeed * moveSpeed * Time.deltaTime);
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

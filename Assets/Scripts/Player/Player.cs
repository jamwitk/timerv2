using System.Collections;
using Game;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public Joystick joystick;
    
        public float moveSpeed;
        public float jumpForce;
    
        [HideInInspector] public bool isGrounded;
        [HideInInspector] public bool isCrunched;
        [HideInInspector] public bool isJumpedToPlane = true;
        [HideInInspector] public float privateMoveSpeed;
        private Vector3 _movement = Vector3.zero;
    
    
        private Rigidbody _rigidbody;
        private const float GravityModifier = 10;
    
        void Start()
        {
            privateMoveSpeed = moveSpeed;
            _rigidbody = GetComponent<Rigidbody>();
            Physics.gravity *= GravityModifier;
        }
    
        private void Update()
        {
        
            WalkAround();
        
            if (isGrounded && !isCrunched)
            {
                StartCoroutine(Jump());

            }

            if (Input.GetKey(KeyCode.Space))
            {
                SpaceDown();
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                SpaceUp();   
            }

        
            if (transform.position.y<=-1)
            {
                GameManager.instance.Die();
            }
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
        private void WalkAround()
        {
            if (GameManager.instance.isWindows)
            {
                //Getting inputs 
                _movement.x = Input.GetAxis("Horizontal") * moveSpeed;
                _movement.z = Input.GetAxis("Vertical") * moveSpeed;
                //Moving character on x and y axis
                transform.Translate(_movement.x * moveSpeed * Time.deltaTime,0f,_movement.z * moveSpeed * Time.deltaTime);
            }
            else if(GameManager.instance.isAndroid)
            {
            
                transform.Translate(joystick.Horizontal * moveSpeed * Time.deltaTime * moveSpeed, 0f,
                    joystick.Vertical * moveSpeed * moveSpeed * Time.deltaTime);
            }

        }
        private IEnumerator Jump()
        {
            isGrounded = false;
            _rigidbody.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            yield return new WaitForSeconds(1f);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public ScoreManager scoreManager;
    public Joystick joystick;
    
    public float moveSpeed;
    public float jumpForce;
    
    [HideInInspector] public bool isGrounded;
    [HideInInspector] public bool isCrunched;
    
    public float _moveSpeed;
    private Vector3 _movement = Vector3.zero;
   
    public MaterialManager materialManager;
    
    [HideInInspector] public bool isJumpedToPlane = true;
    
    private Rigidbody _rigidbody;
    private const float GravityModifier = 10;

    private AudioManager audioManager;
    private GameManager gameManager;
    
    void Start()
    {
        
        audioManager = AudioManager.Instance;
        gameManager = GameManager.instance;
        
        _moveSpeed = moveSpeed;
        
        _rigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= GravityModifier;
    }

    private void Update()
    {
        
        WalkAround();
        
        //Jumping every second
        if (isGrounded && !isCrunched)
        {
            StartCoroutine(JumpEverySecond());
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
            gameManager.Die();
        }
    }

    public void SpaceDown()
    {
        moveSpeed = 0;
        isCrunched = true;
    }

    public void SpaceUp()
    {
        moveSpeed = _moveSpeed;
        isCrunched = false;
    }
    private void WalkAround()
    {
        if (gameManager.isWindows)
        {
            //Getting inputs 
            _movement.x = Input.GetAxis("Horizontal") * moveSpeed;
            _movement.z = Input.GetAxis("Vertical") * moveSpeed;
            //Moving character on x and y axis
            transform.Translate(_movement.x * moveSpeed * Time.deltaTime,0f,_movement.z * moveSpeed * Time.deltaTime);
        }
        else if(gameManager.isAndroid)
        {
            transform.Translate(joystick.Horizontal * moveSpeed * Time.deltaTime * moveSpeed, 0f,
                joystick.Vertical * moveSpeed * moveSpeed * Time.deltaTime);
        }

    }

    private IEnumerator JumpEverySecond()
    {
        isGrounded = false;
        
        _rigidbody.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
        
        yield return new WaitForSeconds(1f);
        
    }

    private void OnCollisionEnter(Collision other)
    {
        isGrounded = true;
        
        switch (other.gameObject.tag)
        {
            case "12Planes":
                {
                    isJumpedToPlane = true;
                    if (other.gameObject.name == "12Plane"+materialManager.random)
                    {
                        gameManager.PlayParticle();
                        
                        gameManager.particle.transform.position = transform.position;

                        StartCoroutine(gameManager.StopParticle());

                        audioManager.Play("JumpPlane");
                        
                        materialManager.planes[materialManager.random].GetComponent<ChangeMaterial>().SetToDefault();
                        
                        materialManager.SetNewTarget(); // Selecting next red random material
                        
                        scoreManager.ScoreCombo++; //adding 100 score 
                        
                        scoreManager.ScoreCalculation(); // Calculating Scores

                        
                    }
                    break;
                }
        }
    }

    
}

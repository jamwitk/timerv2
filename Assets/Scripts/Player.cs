using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public ScoreManager scoreManager;
    public CameraShaking cameraShaking;
    
    public float moveSpeed;
    public float jumpForce;
    public GameObject gameOverPanel;
    [HideInInspector] public bool isGrounded;
    [HideInInspector] public bool isCrunched;
    
    public float _moveSpeed;
    private Vector3 _movement = Vector3.zero;
   
    public ButtonScript buttonScript;
    
    [HideInInspector] public bool isJumpedToPlane = true;
    public RotateClock[] clocks;
    
    public GameObject spaceButton;
    public GameObject joystick;
    public GameObject pauseButton;
    
    private Rigidbody _rigidbody;
    private float gravityModifier = 10;
    
    private AudioManager audioManager;
    void Start()
    {
        audioManager = AudioManager.Instance;
        
        _moveSpeed = moveSpeed;
        
        _rigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
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
             moveSpeed = 0;
            isCrunched = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            moveSpeed = _moveSpeed;
            isCrunched = false;
        }

        
        if (transform.position.y<=-1)
        {
            PauseGame();
            cameraShaking.CameraShake();
            Invoke(nameof(_GameOverPanel),0.75f);
            
            transform.position = new Vector3(0, 1, -8);

        }
       

    }

    private void WalkAround()
    {
        //Getting inputs 
        _movement.x = Input.GetAxis("Horizontal") * moveSpeed;
        _movement.z = Input.GetAxis("Vertical") * moveSpeed;
        
        //Moving character on x and y axis
        transform.Translate(_movement.x * moveSpeed * Time.deltaTime,0f,_movement.z * moveSpeed * Time.deltaTime);

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
                    if (other.gameObject.name=="12Plane"+buttonScript.random)
                    {
                        particleSystem.Play();
                        particleSystem.transform.position = transform.position;
                        Invoke(nameof(StopParticle),0.5f);
                        audioManager.Play("JumpPlane");
                        buttonScript.planes[buttonScript.random].GetComponent<ChangeMaterial>().SetToDefault();
                        buttonScript._ChangeToCustom(); // Selecting next red random material
                        scoreManager.ScoreCombo++; //adding 100 score 
                        scoreManager.ScoreCalculation(); // Calculating Scores
                    }
                    break;
                }
        }
    }

    public void StopParticle()
    {
        particleSystem.Stop();
    }
    public void PauseGame()
    {
        pauseButton.SetActive(false);
        joystick.SetActive(false);
        spaceButton.SetActive(false);
        clocks[0].rotateSpeed = 0;
        clocks[1].rotateSpeed = 0;
        moveSpeed = 0;
        jumpForce = 0;
        isJumpedToPlane = true;
       
    }

    public void _GameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
    public void RestartCharacter()
    {
        // pauseButton.SetActive(true);
        // joystick.SetActive(true);
        // spaceButton.SetActive(true);
        moveSpeed = _moveSpeed;
        jumpForce = 20;
        isGrounded = true;
        gameObject.transform.position = new Vector3(0,1,-8);
    }
}

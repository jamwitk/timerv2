using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public ScoreManager _ScoreManager;
    public CameraShaking _cameraShaking;
    private float gravityModifier = 10;
    
    public float moveSpeed;
    public float jumpForce;
    public GameObject GameOverPanel;
    public bool isGrounded;
    private bool _isCrunched;
    private MeshRenderer _meshRenderer;
    private float _moveSpeed;
    private Vector3 _movement = Vector3.zero;
    public RotateClock[] clocks;
    public ButtonScript buttonScript;
    private Rigidbody _rigidbody;
    [NonSerialized]
    public bool isJumpedToPlane = true;
    void Start()
    {
        _moveSpeed = moveSpeed;
        
        _rigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
       
        
    }

    private void Update()
    {
        
        WalkAround();
        
        //Jumping every second
        if (isGrounded && !_isCrunched)
        {
            StartCoroutine(JumpEverySecond());
        }

        if (Input.GetKey(KeyCode.Space))
        {
             moveSpeed = 0;
            _isCrunched = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            moveSpeed = _moveSpeed;
            _isCrunched = false;
        }

        
        if (transform.position.y<=-1)
        {
            PauseGame();
            _cameraShaking.CameraShake();
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
        _rigidbody.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
        isGrounded = false;
        yield return new WaitForSeconds(1f);
    }

    private void OnCollisionEnter(Collision other)
    {

        switch (other.gameObject.tag)
        {

            case "Plane":
                {
                    isGrounded = true;

                    break;
                }
            case "12Planes":
                {
                    isGrounded = true;
                    isJumpedToPlane = true;
                    if (other.gameObject.name=="12Plane"+buttonScript.random)
                    {
                        
                        buttonScript.planes[buttonScript.random].GetComponent<ChangeMaterial>().SetToDefault();
                        buttonScript._ChangeToCustom(); // Selecting next red random material
                        _ScoreManager.ScoreCombo++; //adding 100 score 
                        _ScoreManager.ScoreCalculation(); // Calculating Scores
                    }
                    break;
                }
        }
    }

    public void PauseGame()
    {
        //Write "You died text"
        clocks[0].donmeHizi = 0;
        clocks[1].donmeHizi = 0;
        moveSpeed = 0;
        jumpForce = 0;
        isJumpedToPlane = true;
        Invoke("_GameOverPanel",0.75f); // 0.75f saniye sonra '_GameOverPanel' metodu çalışır
        //_ScoreManager.SetGameOverText(); // Sahnedeki toplam skoru GameOverPanelindeki textboxa aktarmak için
    }

    private void _GameOverPanel()
    {
        GameOverPanel.SetActive(true);
    }
    public void RestartCharacter()
    {
        moveSpeed = _moveSpeed;
        jumpForce = 20;
        isGrounded = true;
    }
    
   
    


}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateClock : MonoBehaviour
{
    private bool _akrep;
    private bool _yelkovan;
    public int rotateSpeed;
    public Player player;
    private CameraShaking _cameraShaking;
    private AudioManager audioManager;
    private void Start()
    {
        audioManager = AudioManager.Instance;
        
        _cameraShaking = GameObject.Find("Main Camera").GetComponent<CameraShaking>();
        if (gameObject.name == "akrep")
        {
            _akrep = true;
        }
        else
        {
            _yelkovan = true;
        }
    }

    private void RotateAkrep()
    {
        transform.Rotate(0,(rotateSpeed * 0.3f) * Time.deltaTime,0);
    }

    private void RotateYelkovan()
    {
        transform.Rotate(0,rotateSpeed * Time.deltaTime,0);
    }

    private void Update()
    {
        if (_akrep)
        {
            RotateAkrep();
        }
        else if (_yelkovan)
        {
            RotateYelkovan();
        }
    }

    public void ReverseClocks()
    {
        rotateSpeed = rotateSpeed * -3 / 2;

    }
    private void OnCollisionEnter(Collision other)
    {
        audioManager.Play("Punch");
        player.PauseGame();
        _cameraShaking.CameraShake();
        player.Invoke(nameof(player._GameOverPanel),0.75f);
        
    }
}

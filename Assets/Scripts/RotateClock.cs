using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateClock : MonoBehaviour
{
    private bool _akrep;
    private bool _yelkovan;
    public int donmeHizi;
    private Player _player;
    private CameraShaking _cameraShaking;
    private void Start()
    {
        _cameraShaking = GameObject.Find("Main Camera").GetComponent<CameraShaking>();
        if (gameObject.name == "akrep")
        {
            _akrep = true;
        }
        else
        {
            _yelkovan = true;
        }

        _player = GameObject.Find("Cube").GetComponent<Player>();
    }

    private void RotateAkrep()
    {
        transform.Rotate(0,(donmeHizi * 0.3f) * Time.deltaTime,0);
    }

    private void RotateYelkovan()
    {
        transform.Rotate(0,donmeHizi * Time.deltaTime,0);
    }
    void Update()
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
        donmeHizi = donmeHizi * -2;
    }
    private void OnCollisionEnter(Collision other)
    {
        _player.PauseGame();
        _cameraShaking.CameraShake();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Random = System.Random;

public class ButtonScript : MonoBehaviour
{
    public Player _player;
    private RotateClock _rotateClock;
    private ChangeMaterial _changeMaterial;
    private Random _random;
    public GameObject[] planes;
    [NonSerialized]public int random;

    private void Start()
    {
        _random = new Random();
        _ChangeToCustom();
    }
    public void RandomizePlanes()
    {
        for (int i = 0; i < 12; i++)
        {
            planes[i].GetComponent<ChangeMaterial>().RandomMaterial();
        }
    }

    public int RandomCustomIndex()
    {
        return _random.Next(11);
    }
    public void SettingDafueltMaterials()
    {
        for (int i = 0; i < planes.Length; i++)
        {
           
                planes[i].GetComponent<ChangeMaterial>().GetDefaultMaterial();
            
        }
    }
    public void _ChangeToCustom()
    {
       
        if (_player.isJumpedToPlane)
        {
            random = RandomCustomIndex();
            planes[random].GetComponent<ChangeMaterial>().ChangeToCustom();
            _player.isJumpedToPlane = false;
        }
        
    }


}

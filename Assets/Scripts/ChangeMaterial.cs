using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;
using UnityEngine.TextCore;

public class ChangeMaterial : MonoBehaviour
{
    //Materials
    public Material[] materials;
    public Material customMaterial;
    private Material _defaultMaterial;
    private Material _defaultMaterialr;

    //Main mesh
    private MeshRenderer _mesh;
    //Random index
    private int _randomMaterialIndex;
    private Random _random;
    private void Start()
    {
        //Set _random 
         _random = new Random();
         
         //Set Mesh Renderer to _mesh as component
        _mesh = GetComponent<MeshRenderer>();
        
        //Getting Default material for turn back
        GetDefaultMaterial();
    }

    public void GetDefaultMaterial()
    {
        _defaultMaterial = _mesh.material;
    }
    public void RandomMaterial()
    {
       _randomMaterialIndex = _random.Next(0,materials.Length);
       _mesh.material = materials[_randomMaterialIndex];
        _defaultMaterialr = _mesh.material;
        
    }
    public void ChangeToCustom()
    {
        //Setting custom material to plane
        _mesh.material = customMaterial;
    }

    public void SetToDefault()
    {
        //Setting back default material 
        _mesh.material = _defaultMaterial;
    }
    

}

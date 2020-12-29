using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MaterialManager : MonoBehaviour
{
    public int randomMaterialIndex;
    public int randomColorIndex;
    public Material customMaterial;
    public Material defaultMaterial;
    private Material _defaultMaterial;
    
    public MeshRenderer[] planes;
    public Material[] materials;

    private void Start()
    {
        GetDefaultMaterial();
        
        
    }

    public void GetDefaultMaterial()
    {
       _defaultMaterial = planes[0].material;
    }
    private int RandomMaterialIndex()
    {
      randomMaterialIndex = Random.Range(0, planes.Length);
      return randomMaterialIndex;
    }

    private int RandomColorIndex()
    {
        randomColorIndex = Random.Range(0, materials.Length);
        return randomColorIndex;
    }
    public void RandomCustomPlane(int randomIndex)
    {
        planes[randomIndex].material = customMaterial;
    }

    public void RandomColorPlanes(int randomColorIndex)
    {
        foreach (var plane in planes)
        {
            plane.material = materials[randomColorIndex];
        }
    }
    

}

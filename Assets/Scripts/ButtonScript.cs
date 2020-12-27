using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ButtonScript : MonoBehaviour
{
    public Player player;
    private RotateClock _rotateClock;
    public ChangeMaterial[] planes;
    [HideInInspector]public int random;

    private void Start()
    {
        SettingDefaultMaterials();
        _ChangeToCustom();
    }

   

    private int RandomMaterialIndex()
    {
        return Random.Range(0, planes[0].materials.Length);
    }

    public void RandomizePlanes()
    {
        random = RandomMaterialIndex();
        for (var i = 0; i < 12; i++)
        {
            planes[i].RandomMaterial(random);
        }
    }

    private static int RandomCustomIndex()
    {
        return Random.Range(0,12);
    }
    public void SettingDefaultMaterials()
    {
        foreach (var plane in planes)
        {
            plane.GetDefaultMaterial();
        }
    }
    public void _ChangeToCustom()
    {
        if (!player.isJumpedToPlane) return;
        random = RandomCustomIndex();
        planes[random].ChangeToCustom();
        player.isJumpedToPlane = false;

    }


}

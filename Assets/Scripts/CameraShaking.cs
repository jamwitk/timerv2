using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraShaking : MonoBehaviour
{
    public float CameraPower;
    public float CameraDuration;
    void Start()
    {
        DOTween.Init();
    }

    public void CameraShake()
    {
        transform.DOShakePosition(CameraDuration,CameraPower);
        
    }
}

using UnityEngine;
using DG.Tweening;
public class CameraShaking : MonoBehaviour
{
    public float cameraPower;
    public float cameraDuration;
    void Start()
    {
        DOTween.Init();
    }

    public void CameraShake()
    {
        transform.DOShakePosition(cameraDuration,cameraPower);
        
    }
}

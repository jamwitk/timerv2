using DG.Tweening;
using UnityEngine;

namespace Game
{
    public class CameraController : Singleton<CameraController>
    {
        public float cameraPower;
        public float cameraDuration;

        private void Start()
        {
            DOTween.Init();
        }

        public void Shake()
        {
            transform.DOShakePosition(cameraDuration,cameraPower);
        }
    } 
}


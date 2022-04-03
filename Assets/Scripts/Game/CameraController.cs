using System;
using DG.Tweening;

namespace Game
{
    public class CameraController : Singleton<CameraController>
    {
        public float cameraPower;
        public float cameraDuration;

        private void Start()
        {
            DOTween.Init();
            GameManager.Instance.OnFinishGame += Shake;
        }

        private void OnDestroy()
        {
            GameManager.Instance.OnFinishGame -= Shake;
        }

        public void Shake()
        {
            transform.DOShakePosition(cameraDuration,cameraPower);
        }
    } 
}


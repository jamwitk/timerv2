using System;
using Game;
using UnityEngine;

namespace Clock
{
    public class ClockCollusion : MonoBehaviour
    {
        private CameraShaking _cameraShaking;

        private void Start()
        {
            _cameraShaking = FindObjectOfType<CameraShaking>();
        }
        private void OnCollisionEnter(Collision other)
        {
            if(other.transform.CompareTag("Player"))
            {
              AudioManager.Instance.Play("Punch");
              _cameraShaking.CameraShake();
              GameManager.instance.PauseGame();
              //Show ad Panel
              StartCoroutine(GameManager.instance.DelayGameOverPanel());
            }
        }
    }
}

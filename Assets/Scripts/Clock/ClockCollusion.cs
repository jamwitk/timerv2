using Game;
using UnityEngine;

namespace Clock
{
    public class ClockCollusion : MonoBehaviour
    {
        [SerializeField] private CameraShaking cameraShaking;
        private void OnCollisionEnter(Collision other)
        {
            if(other.transform.CompareTag("Player"))
            {
              AudioManager.Instance.Play("Punch");
              cameraShaking.CameraShake();
              GameManager.instance.PauseGame();
              //Show ad Panel
              StartCoroutine(GameManager.instance.DelayGameOverPanel());
            }
        }
    }
}

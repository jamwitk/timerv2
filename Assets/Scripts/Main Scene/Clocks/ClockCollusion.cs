using Game;
using UnityEngine;

namespace Clocks
{
    public class ClockCollusion : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            if (!other.transform.CompareTag("Player") || !GameManager.Instance.isGame) return;
            GameManager.Instance.FinishGame();
        }
    }
}

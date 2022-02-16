using Game;
using UnityEngine;

namespace Clocks
{
    public class ClockCollusion : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            if (!other.transform.CompareTag("Player") || !GameManager.instance.isGame) return;
            GameManager.instance.FinishGame();
        }
    }
}

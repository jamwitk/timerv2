using Game;
using UnityEngine;

namespace Clocks
{
    public class ClockCollusion : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (!other.transform.CompareTag("Player") || !GameManager.instance.isGame) return;
            GameManager.instance.FinishGame();
        }
    }
}

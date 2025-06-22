using Game;
using UnityEngine;

namespace Clocks
{
    public class ClockCollusion : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            if (!other.transform.CompareTag("Player") || !GameManager.Instance.isGame) return;
            Time.timeScale = 0;
            MessageBox.Instance.Show();
            //GameManager.Instance.FinishGame();
        }
        
    }
}

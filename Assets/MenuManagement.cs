using UnityEngine;

public class MenuManagement : MonoBehaviour
{
        public GameObject marketPanel;
        public GameObject gamePanel;

        
        public void OnClickMarketButton()
        {
            marketPanel.SetActive(true);      
            gamePanel.SetActive(false);
        }

        public void OnClickBackMarketButton()
        {
            marketPanel.SetActive(false);
            gamePanel.SetActive(true);
        }
}

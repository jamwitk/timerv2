using Game;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) || Input.touchCount >= 1)
        {
            GameManager.instance.ContinueGame();
        }
    }

    public void OnClick()
    {
        //On Click button going back to menu 
        SceneManager.LoadScene("Scene 0");
    }
}

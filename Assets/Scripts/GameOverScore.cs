using UnityEngine;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour
{
    public Text gameOverScoreText;
    public GameObject[] clocks;
    public ButtonScript gameManager;
    public Player player;
    public ScoreManager scoreManager;
    private RotateClock _rotateClock;
    private RotateClock _rotateClock1;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.instance;
        _rotateClock1 = clocks[1].GetComponent<RotateClock>();
        _rotateClock = clocks[0].GetComponent<RotateClock>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.touchCount > 0)
        { 
            //continue game
            clocks[0].transform.rotation = Quaternion.Euler(Vector3.zero); // Reset rotation yelkovan
            clocks[1].transform.rotation = Quaternion.Euler(Vector3.zero); // Reset rotation akrep
            _rotateClock.rotateSpeed = 60;  // Give rotate speed to rotation
            _rotateClock1.rotateSpeed = 60;  // Give rotate speed to rotation
            
            gameManager.RandomizePlanes(); // Setting random color to all plane
            gameManager.SettingDefaultMaterials(); //Gets new default material valıe
            
            _gameManager.RestartGame(); // Start character move and jump
            gameManager._ChangeToCustom(); // Select one random red material
            scoreManager.ResetText(); // reset score
            gameObject.SetActive(false); // Close GAME over panel
        }
    }

    public void SetGameOverScore()
    {
        gameOverScoreText.text = FindObjectOfType<ScoreManager>().Score.ToString(); // ScoreManager objesini bulup oradaki Score değişkenine ulaşır
    }
}

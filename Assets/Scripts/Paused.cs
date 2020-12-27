using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paused : MonoBehaviour
{
    public Player pausedPlayer;
    public GameObject continueBtn;

    private RotateClock _rotateClock;
    private RotateClock _rotateClock1;

    // Start is called before the first frame update
    private void Start()
    {
        _rotateClock1 = pausedPlayer.clocks[0].GetComponent<RotateClock>();
        _rotateClock = pausedPlayer.clocks[1].GetComponent<RotateClock>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButton("Cancel"))
        {
            PausedGame();
        }

    }
    public void PausedGame()
    {
        pausedPlayer.PauseGame();
        continueBtn.SetActive(true);
    }
    public void ContinueGame()
    {
        _rotateClock1.rotateSpeed = 60;
        _rotateClock.rotateSpeed = 60;
        pausedPlayer.RestartCharacter();
        pausedPlayer.isJumpedToPlane = false;
        continueBtn.SetActive(false);
        pausedPlayer.gameOverPanel.SetActive(false);
        
    }
}

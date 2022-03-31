using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.UI;


public class PlayGamesService : MonoBehaviour
{
    public int playerScore;
    string leaderboardID = "";
    string achievementID = "";
    public static PlayGamesPlatform platform;
    public Text screenText;
    void Start()
    {
        
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        

        Social.Active.localUser.Authenticate(success =>
        {
            if (success)
            {
                screenText.text = "Logged in successfully";
                Debug.Log("Logged in successfully");
            }
            else
            {
                screenText.text = "Login Failed";
                Debug.Log("Login Failed");
            }
        });
        AddScoreToLeaderboard();
    }

    public void AddScoreToLeaderboard()
    {
        if (Social.Active.localUser.authenticated)
        {
            Social.ReportScore(playerScore, leaderboardID, success => { });
        }
    }

    public void ShowLeaderboard()
    {
        if (Social.Active.localUser.authenticated)
        {
            PlayGamesPlatform.Activate().ShowLeaderboardUI();
        }
    }

    public void ShowAchievements()
    {
        if (Social.Active.localUser.authenticated)
        {
            PlayGamesPlatform.Activate().ShowAchievementsUI();
        }
    }

    public void UnlockAchievement()
    {
        if (Social.Active.localUser.authenticated)
        {
            Social.ReportProgress(achievementID, 100f, success => { });
        }
    }
}
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private string _leaderboardID = "CgkIpK-z4ukVEAIQAQ";
    void Start()
    {
        var configuration = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(configuration);
        PlayGamesPlatform.Activate();
        SignIn();
        AddScoreToLeaderBoard(_leaderboardID,0);
    }

    private void SignIn()
    {
        Social.localUser.Authenticate(success =>
        {
            print(success);
        });
    }

    public static void AddScoreToLeaderBoard(string leaderboardID, long score)
    {
        Social.ReportScore(score,leaderboardID,success => {});
    }
    public static void ShowLeaderBoardsUI()
    {
        Social.ShowLeaderboardUI();
    }
}

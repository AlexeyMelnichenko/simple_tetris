using Assets.Scripts.UI;
using UnityEngine;

public class Application : MonoBehaviour
{
    [SerializeField] private ScreenManager _screenManager;
    [SerializeField] private Game _gamePrefab;

    private async void Start()
    {
        var lobbyScreen = _screenManager.Open<LobbyScreen>();
        var result = await lobbyScreen.Result;

        if(result == ScreenResult.Ok)
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        _screenManager.Open<GameScreen, GameScreenIntent>(new GameScreenIntent(_gamePrefab));
    }
}

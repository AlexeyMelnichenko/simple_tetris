using UnityEngine;

public class Application : MonoBehaviour
{
    [SerializeField] private ScreenManager _screenManager;

    private void Start()
    {
        _screenManager.Open<LobbyScreen>();
    }

    public void StartGame()
    {

    }
}

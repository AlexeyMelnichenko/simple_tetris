using Assets.Scripts.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] private List<ScreenBase> _registeredScreens;

    private ScreenBase _openedScreen;

    public TScreen Open<TScreen, TIntent>(TIntent intent) where TScreen : ScreenBase where TIntent : EmptyIntent
    {
        var screen = Open<TScreen>();
        if(screen is IIntentContainer<TIntent> screenWithIntent)
        {
            screenWithIntent.SetIntent(intent);
        }

        return screen;
    }

    public TScreen Open<TScreen>() where TScreen : ScreenBase
    {
        var type = typeof(TScreen);
        var screen = _registeredScreens.FirstOrDefault(x => x.GetType() == type);

        if(screen == null)
        {
            throw new System.ArgumentException($"Type {type} does not contains in registered screens list!");
        }

        if(_openedScreen!= null)
        {
            _openedScreen.Close();
        }

        _openedScreen = screen;
        screen.Open();

        return (TScreen)screen;
    }
}
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] private List<ScreenBase> _registeredScreens;

    private ScreenBase _openedScreen;

    public T Open<T>() where T : ScreenBase
    {
        var type = typeof(T);
        if (type != typeof(ScreenBase))
        {
            throw new System.ArrayTypeMismatchException($"Type {type} is not screen type!");
        }

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

        return (T)screen;
    }
}
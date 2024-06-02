using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameGrid _grid;

    public void Init()
    {
        _grid.Init();
    }
}

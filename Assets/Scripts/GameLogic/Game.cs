using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameGrid _grid;
    private int _score;
    private int _lines;

    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            ScoreChanged(_score);
        }
    }

    public int Lines
    {
        get => _lines;
        set
        {
            _lines = value;
            LinesChanged(_lines);
        }
    }

    public event Action<int> ScoreChanged;
    public event Action<int> LinesChanged;

    public void Init()
    {
        _grid.Init();

        _score = 0;
        _lines = 0;
    }
}

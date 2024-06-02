using UnityEngine;

public class GameGrid : MonoBehaviour
{
    [SerializeField]
    private Row[] _rows;

    public Row[] Rows => _rows;

    public void Init()
    {
        for (int i = 0; i < _rows.Length; i++)
        {
            _rows[i].Init(i);
        }
    }

    public bool IsCellEmpty(Vector2Int position)
    {
        return _rows[position.y].Cells[position.x].IsEmpty;
    }
}

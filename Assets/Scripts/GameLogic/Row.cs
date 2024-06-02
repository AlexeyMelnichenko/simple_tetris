using System.Linq;
using UnityEngine;

public class Row : MonoBehaviour
{
    [SerializeField]
    private Cell[] _cells;

    public Cell[] Cells => _cells;
    public bool IsFull => _cells.All(c => !c.IsEmpty);

    public int Index { get; private set; }
    
    public void Init(int index)
    {
        Index = index;

        for (int i = 0; i < _cells.Length; i++)
        {
            _cells[i].Init(new Vector2Int(i, Index));
        }
    }
}

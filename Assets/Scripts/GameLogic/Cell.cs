using UnityEngine;

public class Cell : MonoBehaviour
{
    private Transform _segment;

    public Vector2 Position { get; private set; }
    public Vector2 LocalPosition { get; private set; }
    public bool IsEmpty => _segment == null;
    
    public void Init(Vector2 initialPosition)
    {
        Position = initialPosition;
        LocalPosition = initialPosition;
        RemoveSegment();
    }

    public void AddSegment(Transform segment)
    {
        _segment = segment;
        _segment.SetParent(transform);
    }

    public void RemoveSegment()
    {
        if (!IsEmpty)
        {
            Destroy(_segment.gameObject);
            _segment = null;
        }
    }
}

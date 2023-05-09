using UnityEngine;

public class Drawing : MonoBehaviour
{
    [SerializeField]
    private float _maxAllowableError;

    private LineRenderer _lineRenderer;

    private Vector2 _currentPosition;

    private int _size;

    private bool _isDrawedLine;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _size = 1;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (_isDrawedLine)
            {
                ClearLineRenderer();
            }
            Draw();
        }
        if (Input.GetMouseButtonUp(0))
        {
            _isDrawedLine = true;
        }
    }

    private void Draw()
    {
        if (Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), _currentPosition) >= _maxAllowableError)
        {
            _lineRenderer.positionCount = _size;

            _currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _lineRenderer.SetPosition(_size - 1, _currentPosition);
            _size++;
        }
    }
    private void ClearLineRenderer()
    {
        _lineRenderer.positionCount = 0;
        _size = 1;
        _isDrawedLine = false;
    }
}

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Wire : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    private Image _image;
    private LineRenderer _lineRenderer;
    private Canvas _canvas;
    private bool _isDraggedStart = false;
   
    public void OnDrag(PointerEventData eventData){}
    public void OnBeginDrag(PointerEventData eventData)
    {
        _isDraggedStart = true;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        _isDraggedStart = false;
    }

     private void Awake() {
        _image = GetComponent<Image>();
        _lineRenderer = GetComponent<LineRenderer>();
        _canvas = GetComponentInParent<Canvas>();
    }

    void Update()
    {
        if (_isDraggedStart)
        {
            Debug.Log("dragg");
            Vector2 movePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _canvas.transform as RectTransform,
                Input.mousePosition,
                _canvas.worldCamera,
                out movePos
            );
            Vector3 offset = new Vector3(0.5f, 0f, 0f);
            _lineRenderer.SetPosition(0, transform.position + offset);
            _lineRenderer.SetPosition(1, _canvas.transform.TransformPoint(movePos)+ offset);

        }
        else
        {
             _lineRenderer.SetPosition(0, Vector3.zero);
            _lineRenderer.SetPosition(1, Vector3.zero);
        }
    }
}

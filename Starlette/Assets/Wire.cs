using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Wire : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private string dataType;
    private Image _image;
    private LineRenderer _lineRenderer;
    private Canvas _canvas;
    private bool _isDraggedStart = false;
    public bool isLeftWire;
    public bool isSuccess = false;
    private WireTask _wireTask;
    public void OnDrag(PointerEventData eventData) { }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isLeftWire) { return; }
        if (isSuccess) { return; }
        _isDraggedStart = true;
        _wireTask.currentDraggedWire = this;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (_wireTask.currentHoveredWire != null)
        {
            Debug.Log(dataType);
            Debug.Log(_wireTask.getValueByDataType(dataType).ToString());
            Debug.Log(_wireTask.currentHoveredWire.GetComponentInChildren<TMPro.TextMeshProUGUI>().text);
            if (_wireTask.getValueByDataType(dataType).ToString() == _wireTask.currentHoveredWire.GetComponentInChildren<TMPro.TextMeshProUGUI>().text && !_wireTask.currentHoveredWire.isLeftWire)
            {
                isSuccess = true;
                _wireTask.currentHoveredWire.isSuccess = true;
            }
        }
        _isDraggedStart = false;
        _wireTask.currentDraggedWire = null;
    }

    private void Awake()
    {
        _image = GetComponent<Image>();
        _lineRenderer = GetComponent<LineRenderer>();
        _canvas = GetComponentInParent<Canvas>();
        _wireTask = GetComponentInParent<WireTask>();
        Debug.Log(_wireTask);
    }

    void Update()
    {
        if (_isDraggedStart)
        {
            Vector2 movePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _canvas.transform as RectTransform,
                Input.mousePosition,
                _canvas.worldCamera,
                out movePos
            );
            Vector3 offset = new Vector3(0.5f, 0f, 0f);
            _lineRenderer.SetPosition(0, transform.position + offset);
            _lineRenderer.SetPosition(1, _canvas.transform.TransformPoint(movePos) + offset);

        }
        else
        {
            if (!isSuccess)
            {
                _lineRenderer.SetPosition(0, Vector3.zero);
                _lineRenderer.SetPosition(1, Vector3.zero);
            }
        }

        bool isHovered = RectTransformUtility.RectangleContainsScreenPoint(transform as RectTransform, Input.mousePosition, _canvas.worldCamera);
        if (isHovered)
        {
            _wireTask.currentHoveredWire = this;
        }

    }

    public void setDataType(string dataType)
    {
        this.dataType = dataType;
    }

   
}

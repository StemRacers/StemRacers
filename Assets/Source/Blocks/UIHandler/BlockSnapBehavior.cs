using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BlockSnapBehavior : MonoBehaviour, IDropHandler 
{
    public Transform attachPoint;
    public Vector2 snapPositionOffset;

    public Image highlight;

    private void Awake() {
        highlight = GetComponent<Image>();
        if (highlight != null) highlight.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (highlight != null) highlight.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (highlight != null) highlight.enabled = false;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent<RectTransform>(out var block))
        {
            block.SetParent(attachPoint);
            block.anchoredPosition = Vector2.zero + snapPositionOffset;
        }
    }
}

using UnityEngine.EventSystems;
using UnityEngine;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            RectTransform draggedObject = eventData.pointerDrag.GetComponent<RectTransform>();
            DragDrop dragDropScript = eventData.pointerDrag.GetComponent<DragDrop>();

            if (dragDropScript != null)
            {
                draggedObject.anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                dragDropScript.SetDroppedOnSlot(true); // Slotta býrakýldýðýný iþaretle
            }
        }
    }
}


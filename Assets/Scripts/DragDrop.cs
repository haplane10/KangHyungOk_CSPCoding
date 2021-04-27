using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    Vector2 oriPos;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        //foreach (var hovered in eventData.hovered)
        //{
        //    if (hovered.gameObject.name.Contains("BGPanel"))
        //    {
        //        rectTransform.SetParent(eventData.hovered[0].transform);
        //        return;
        //    }
        //}
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        foreach (var hovered in eventData.hovered)
        {
            Debug.Log(1);
            if (hovered.GetComponent<Slot>() != null)
            {
                Debug.Log(2);
                rectTransform.SetParent(hovered.transform);
                rectTransform.anchoredPosition = Vector2.zero;
                return;
            }
        }
        rectTransform.anchoredPosition = oriPos;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        oriPos = GetComponent<RectTransform>().anchoredPosition;
    }
}

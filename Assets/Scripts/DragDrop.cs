using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Image DanceImage;

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
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta;

        //foreach (var hovered in eventData.hovered)
        //{
        //    if (hovered.gameObject.name.Contains("BGPanel"))
        //    {
        //        rectTransform.transform.parent = eventData.hovered[0].transform;
        //        return;
        //    }
        //}
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        foreach (var hovered in eventData.hovered)
        {
            if (hovered.GetComponent<Slot>() != null)
            {
                rectTransform.transform.parent = hovered.transform;
                rectTransform.anchoredPosition = Vector2.zero;
                if (DanceImage != null)
                {
                    GameManager.Instance.DanceImages.Add(DanceImage.sprite);
                }
                else
                {
                    GetComponent<Button>().enabled = true;
                }
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

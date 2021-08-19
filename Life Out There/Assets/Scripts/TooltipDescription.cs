using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipDescription : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    string tooltipString;
    private GameObject tooltip;

    public void Start()
    {
        tooltip = GameObject.Find("Tooltip");
    }
    public void SetTooltipText(string tooltipText)
    {
        tooltipString = tooltipText;
    }

    public string GetTooltipText()
    {
        return tooltipString;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.transform.position = eventData.position;
        tooltip.GetComponent<Tooltip>().ShowTooltip(tooltipString);
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // tooltipText.SetText("This is a tooltip.");
        tooltip.GetComponent<Tooltip>().HideTooltip();
    }
}


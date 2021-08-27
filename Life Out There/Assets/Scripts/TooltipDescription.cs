using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipDescription : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    string tooltipString;
    private GameObject tooltip;


    //Doing this by game object validation didnt work
    //Attempt 1 is creating a Tag and checking agaisnt that 
    //Attempt 2 create new layer and checking against that
    //string variable for to verify check
    //
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
            Debug.Log(eventData.pointerCurrentRaycast.gameObject + "OnPointerEnter");
            if (eventData.pointerCurrentRaycast.gameObject.layer == 7)
            {
                tooltip.transform.position = eventData.position;
                Tooltip temp = tooltip.GetComponent<Tooltip>();
                if (temp != null)
                {
                    temp.ShowTooltip(tooltipString);
                }
            }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
         Debug.Log(eventData.pointerCurrentRaycast.gameObject + "OnPointerExit");
         // tooltipText.SetText("This is a tooltip.");
         if (eventData.pointerCurrentRaycast.gameObject.layer != 7)
         {
            Tooltip temp = tooltip.GetComponent<Tooltip>();
            if (temp != null)
            {
                    temp.HideTooltip();
            }
         }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Tooltip : MonoBehaviour
{
    private static Tooltip instance;

    [SerializeField] private Camera uiCamera;

    private TextMeshProUGUI tooltipText;
    private RectTransform backgroundRectTransform;


    private void Awake()
    {
        instance = this;
        backgroundRectTransform = transform.Find("Background").GetComponent<RectTransform>();
        tooltipText = transform.Find("Information").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
       
    }

     public void ShowTooltip(string tooltipString)
    {
        gameObject.SetActive(true);
        tooltipText.SetText(tooltipString);
        tooltipText.ForceMeshUpdate();
        Vector2 textSize = tooltipText.GetRenderedValues(false);
        backgroundRectTransform.sizeDelta = textSize;
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }



}

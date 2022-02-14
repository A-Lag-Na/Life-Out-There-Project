using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardInfoDisplay : MonoBehaviour
{
    public c_Card card;

    public GameObject cardName;
    public GameObject cardType;
    public GameObject cardDescription;
    public GameObject cardCost;
    public GameObject artwork;

    private TextMeshProUGUI tmp = null;

    // Start is called before the first frame update
    void Start()
    {
        tmp = cardName.GetComponent<TextMeshProUGUI>();
        tmp.SetText(card.cardName);
      

        tmp = cardType.GetComponent<TextMeshProUGUI>();
        tmp.SetText(card.type);
      

        tmp = cardDescription.GetComponent<TextMeshProUGUI>();
        tmp.SetText(card.description);
        

        tmp = cardCost.GetComponent<TextMeshProUGUI>();
        tmp.SetText(card.cost.ToString());
      

        Image art = artwork.GetComponent<Image>();
        art.sprite = card.thisImage;  
    }
}

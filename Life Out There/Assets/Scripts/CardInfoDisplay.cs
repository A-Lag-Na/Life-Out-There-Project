using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardInfoDisplay : MonoBehaviour
{
    public Card card;

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
        tmp.SetText(card.cardType);
      

        tmp = cardDescription.GetComponent<TextMeshProUGUI>();
        tmp.SetText(card.cardDescription);
        

        tmp = cardCost.GetComponent<TextMeshProUGUI>();
        tmp.SetText(card.cardCost.ToString());
      

        Image art = artwork.GetComponent<Image>();
        art.sprite = card.artwork;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

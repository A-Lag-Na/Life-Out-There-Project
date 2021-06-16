using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public GameObject attackCard;
    public GameObject blockCard;
    List<GameObject> deck = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i < 4)
            {
                AddCard(attackCard);
            }
            AddCard(blockCard);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCard(GameObject _card)
    {
        deck.Add(_card);
    }

    public GameObject GetCard()
    {

    }



}

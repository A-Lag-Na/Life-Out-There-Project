using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    public GameObject card;
    public GameObject handArea;
    public GameObject UAO;
    public GameObject UAODisplay;

    List<GameObject> deck = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        deck.Add(card);
    }

    public void OnClick()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject playerCard = Instantiate(card, new Vector3(0, 0, 0), Quaternion.identity);
            playerCard.transform.SetParent(handArea.transform, false);
        }

        GameObject playerUAO = Instantiate(UAO, new Vector3(0, 0, 0), Quaternion.identity);
        playerUAO.transform.SetParent(UAODisplay.transform, false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

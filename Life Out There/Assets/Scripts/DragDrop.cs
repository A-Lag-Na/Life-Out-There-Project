using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private bool isSelected = false;
    private bool isplayerOn = false;
    private bool isenemyOn = false;

    public GameObject arrowEmitter;
    public GameObject cardHighlight;

    private GameObject player;
    private GameObject enemy;
    GameObject enemyLight;
    GameObject playerLight;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        enemy = GameObject.FindWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            arrowEmitter.SetActive(true);
        }
        else
        {
            arrowEmitter.SetActive(false);
        }
    }

    public void Selection()
    {
        if(isSelected == false)
        {
            isSelected = true;
            transform.position = new Vector2(transform.position.x, transform.position.y + 50);
            cardHighlight.SetActive(true);
            // Debug.Log("This object is selected and its position is <" + transform.position + ">");

            if (this.name == "AttackCard(Clone)")
            {
                enemyLight = enemy.transform.GetChild(0).gameObject;
                enemyLight.SetActive(true);
                isenemyOn = true;
                Debug.Log("This object is <" + this.name + "> and its highlight is <" + enemyLight.name + ">");
            }
            else if (this.name == "BlockCard(Clone)")
            {
                playerLight = player.transform.GetChild(0).gameObject;
                playerLight.SetActive(true);
                isplayerOn = true;
                Debug.Log("This object is <" + this.name + "> and its highlight is <" + playerLight.name + ">");
            }

        }
        else
        {
            isSelected = false;
            cardHighlight.SetActive(false);
            transform.position = new Vector2(transform.position.x, transform.position.y - 50);
           
            if (isplayerOn)
            {
                playerLight.SetActive(false);
                isplayerOn = false;
            }
            else if(isenemyOn)
            {
                enemyLight.SetActive(false);
                isenemyOn = false;
            }
            //Debug.Log("This object is de-selected and its position is <" + transform.position + ">");
        }
       

    }
    
}

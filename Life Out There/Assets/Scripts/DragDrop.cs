using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private bool isSelected = false;
    private bool isPlayerOn = false;
    private bool isEnemyOn = false;

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
                isEnemyOn = true;
                Debug.Log("This object is <" + this.name + "> and its highlight is <" + enemyLight.name + ">");
            }
            else if (this.name == "BlockCard(Clone)")
            {
                playerLight = player.transform.GetChild(0).gameObject;
                playerLight.SetActive(true);
                isPlayerOn = true;
                Debug.Log("This object is <" + this.name + "> and its highlight is <" + playerLight.name + ">");
            }

        }
        else 
        {
            isSelected = false;
            cardHighlight.SetActive(false);
            transform.position = new Vector2(transform.position.x, transform.position.y - 50);
           
            if (isPlayerOn)
            {
                playerLight.SetActive(false);
                isPlayerOn = false;
            }
            else if(isEnemyOn)
            {
                enemyLight.SetActive(false);
                isEnemyOn = false;
            }
            //Debug.Log("This object is de-selected and its position is <" + transform.position + ">");
        }
       

    }
    
}

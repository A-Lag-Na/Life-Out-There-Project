using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private bool isSelected = false;
    
    public GameObject arrowEmitter;



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
            Debug.Log("This object is selected and its position is <" + transform.position + ">");
        }
        else
        {
            isSelected = false;
            transform.position = new Vector2(transform.position.x, transform.position.y - 50);
            //Debug.Log("This object is de-selected and its position is <" + transform.position + ">");
        }
       

    }
    
}

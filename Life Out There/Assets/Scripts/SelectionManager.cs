using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Debug.Log("Made it Here  " + Physics.Raycast(ray, out hit,100.0f));
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                GameObject selection = hit.transform.gameObject;
                GameObject selectionHighlight = selection.transform.GetChild(0).gameObject;
                if (selectionHighlight != null)
                    selectionHighlight.SetActive(true);
               
            }
        }
      

    }
}

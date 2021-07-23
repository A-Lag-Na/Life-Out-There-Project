using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    private Button backButton;
    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
       backButton = GameObject.Find("Back Button").GetComponent<Button>();
       backButton.onClick.AddListener(BacktoMain);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BacktoMain()
    {
        gameObject.SetActive(false);
        menu.SetActive(true);  
    }

}

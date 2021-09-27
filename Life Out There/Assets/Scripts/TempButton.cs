using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempButton : MonoBehaviour
{
    private Button mapButton;
    public GameObject map;

    // Start is called before the first frame update
    void Start()
    {
        mapButton = GameObject.Find("Map Button").GetComponent<Button>();
        mapButton.onClick.AddListener(BacktoMap);
    }

    private void BacktoMap()
    {
        GameObject screen = GameObject.Find("End Screen");
        screen.SetActive(false);
        map.SetActive(true);
    }
}

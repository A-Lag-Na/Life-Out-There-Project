using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject map, menu, options, credits;

    #region MainMenuProperties
    //private Button startBTN, loadBTN, tutorialBTN, creditsBTN, optionsBTN, exitBTN = null;
    private Button[] buttons;
  
    GameObject music = null;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        buttons = transform.GetComponentsInChildren<Button>();

        buttons[0].onClick.AddListener(StartGame);
        buttons[1].onClick.AddListener(OptionsMenu);
        buttons[2].onClick.AddListener(Credits);
        buttons[3].onClick.AddListener(ExitGame);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartGame()
    {
        menu.SetActive(false);
        map.SetActive(true);
    }

    private void OptionsMenu()
    {
        menu.SetActive(false);
        options.SetActive(true);
    }

    private void Credits()
    {
        menu.SetActive(false);
        credits.SetActive(true);
    }

    private void ExitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                      Application.Quit();
        #endif

    }

}


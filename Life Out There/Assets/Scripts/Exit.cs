using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{

    private Button backButton;
    private Button exitButton;

    // Start is called before the first frame update
    void Start()
    {
        backButton = GameObject.Find("Back Button").GetComponent<Button>();
        backButton.onClick.AddListener(BacktoGame);

        exitButton = GameObject.Find("Exit Button").GetComponent<Button>();
        exitButton.onClick.AddListener(EndGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EndGame()
    {
        SceneManager.LoadScene("TitleMenu");
    }

    private void BacktoGame()
    {
        gameObject.SetActive(false);

    }
    public void TurnOnOptions()
    {
        gameObject.SetActive(true);
    }
}


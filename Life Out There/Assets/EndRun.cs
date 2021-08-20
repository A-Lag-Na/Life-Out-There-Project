using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndRun : MonoBehaviour
{
    private Button exitButton;

    // Start is called before the first frame update
    void Start()
    {
        exitButton = GameObject.Find("Exit Button").GetComponent<Button>();
        exitButton.onClick.AddListener(EndGame);
    }

    private void EndGame()
    {
        SceneManager.LoadScene("TitleMenu");
    }
}

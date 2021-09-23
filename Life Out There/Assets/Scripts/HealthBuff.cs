using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBuff : MonoBehaviour
{
    private GameObject player;
    private Player playerScript;

    public GameObject healthsfx;
    public GameObject restButton;
    public GameObject map;

    private AudioSource aud;
    private bool isSelected = false;

    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
        player = GameObject.FindWithTag("Player");
        if (player != null)
            playerScript = player.GetComponent<Player>();

        Button btn = restButton.GetComponent<Button>();
        btn.onClick.AddListener(Selection);

        aud = healthsfx.GetComponent<AudioSource>();
        
    }
    // Update is called once per frame
    void Update()
    {
        if (isSelected && aud.isPlaying == false)
        {
            StartCoroutine(GetSomeRest());
            GameObject UI = GameObject.Find("UI");
            UI.SetActive(false);
            map.SetActive(true);  
        }

    }
    IEnumerator GetSomeRest()
    {
        playerScript.ResetHealth();
        aud.Play();
        Debug.Log("Should be playing but am not");
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
        yield return null;
    }
    public void Selection()
    {
        isSelected = true;
    }
}

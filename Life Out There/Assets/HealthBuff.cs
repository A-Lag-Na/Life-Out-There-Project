using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBuff : MonoBehaviour
{
    private GameObject player;
    private Player playerScript;

    public AudioSource healthsfx;
    public GameObject map;

    private bool isSelected = false;

    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
        player = GameObject.FindWithTag("Player");
        if (player != null)
            playerScript = player.GetComponent<Player>();

    }
    // Update is called once per frame
    void Update()
    {
        if (isSelected && healthsfx.isPlaying == false)
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
        healthsfx.Play();
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
        yield return null;
    }
    public void Selection()
    {
        isSelected = true;
    }
}

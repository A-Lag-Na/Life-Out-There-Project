using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBuff : MonoBehaviour
{
    private GameObject player;
    public AudioSource healthsfx;
    private Player playerScript;

    private bool isSelected = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null)
            playerScript = player.GetComponent<Player>();

    }
    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            StartCoroutine(GetSomeRest());
        }

    }
    IEnumerator GetSomeRest()
    {
        playerScript.ResetManaCount();
        healthsfx.Play();
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        yield return null;
    }
    public void Selection()
    {
        isSelected = true;
    }
}

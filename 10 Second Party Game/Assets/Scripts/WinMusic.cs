using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMusic : MonoBehaviour
{
    public AudioSource winMusic;
    public int winCondition;
    // Start is called before the first frame update
    void Start()
    {

        AudioSource winMusic = gameObject.GetComponent<AudioSource>();
        GameObject Player = GameObject.Find("Player");
        PlayerController playerController = Player.GetComponent<PlayerController>();
        playerController.win = winCondition;

    }

    // Update is called once per frame
    void Update()
    {
       if (winCondition == 1)
        {
            winMusic.Play();
        }

    }
}

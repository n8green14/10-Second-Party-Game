using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedPlay : MonoBehaviour
{

    private PlayerController playerController;
    

    // Start is called before the first frame update
    void Start()
    {
        AudioSource lossMusic = gameObject.GetComponent<AudioSource>();
        lossMusic.PlayDelayed(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasPickup : MonoBehaviour
{
    public AudioClip audio;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Seat"))
        {

            AudioSource.PlayClipAtPoint(audio, transform.position);
            Destroy(gameObject); // this destroys the collider as well
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    AudioSource audioSource;
    CharacterController cc;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cc.isGrounded == true && Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) && audioSource.isPlaying == false)
        {
            audioSource.volume = Random.Range(0.8f, 1f);
            audioSource.pitch = Random.Range(0.8f, 1.1f);
            audioSource.Play();
        }
        if (audioSource.isPlaying == true && cc.isGrounded == false && Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            audioSource.Stop();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour
{
    public Transform playerReturn;
    public GameObject player;
    
    void Start()
    {
        

        
    }


    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy"))
        {
            //It seems that the Character Controller function does not like being moved so I had to disable it first to move the player.
            CharacterController cc = player.GetComponent<CharacterController>();
            cc.enabled = false;
            player.transform.position = playerReturn.transform.position;
            cc.enabled = true;
            Debug.Log("oops");
        }
    }
}

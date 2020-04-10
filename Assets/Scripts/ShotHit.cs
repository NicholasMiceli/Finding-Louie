using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotHit : MonoBehaviour
{
    //private Rigidbody attachedRigidbody;
    void Start()
    {
       // attachedRigidbody.useGravity = false;
    }


    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }
}

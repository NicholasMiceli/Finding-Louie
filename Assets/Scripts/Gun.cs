using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //public GameObject EnemyBullet;
    public float speed = 300;
    public bool attacking = true;
 
    

   /* void Update()
    {
        
        
        
        if (attacking == true)
        {
            StartCoroutine(Fire());
        }
       
       
    }
    IEnumerator Fire()
    {
        attacking = false;       
        yield return new WaitForSecondsRealtime(1);
        GameObject shoot = Instantiate(EnemyBullet, transform.position, Quaternion.identity) as GameObject;
        Rigidbody shootBody = shoot.GetComponent<Rigidbody>();
        shootBody.AddRelativeForce(shootBody.transform.forward * speed);
        Destroy(shoot, 2.5f);
        attacking = true;
    }*/
    /// <summary>
    /// Public fields
    /// </summary>
    public GameObject m_Projectile;    // this is a reference to your projectile prefab
    public Transform m_SpawnTransform; // this is a reference to the transform where the prefab will spawn

    /// <summary>
    /// Message that is called once per frame
    /// </summary>
    private void Update()
    {
        if (attacking == true)
        {
            StartCoroutine(Fire());
            
        }
    }

    IEnumerator Fire()
    {
        attacking = false;
        yield return new WaitForSecondsRealtime(1);
        Instantiate(m_Projectile, m_SpawnTransform.position, m_SpawnTransform.rotation);
        attacking = true;
    }
}
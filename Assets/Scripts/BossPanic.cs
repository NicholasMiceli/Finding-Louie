using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPanic : MonoBehaviour
{
    public float speed = 300;
    public bool attacking = true;
    public GameObject m_Projectile;    
    public Transform m_SpawnTransform;

    void Start()
    {
        
    }

   
    void Update()
    {
        if (attacking == true)
        {
            StartCoroutine(Fire());

        }
    }
    IEnumerator Fire()
    {
        attacking = false;
        yield return new WaitForSecondsRealtime(.2f);
        Instantiate(m_Projectile, m_SpawnTransform.position, m_SpawnTransform.rotation);
        attacking = true;
    }
}

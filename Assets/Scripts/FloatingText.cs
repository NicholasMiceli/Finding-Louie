using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public Vector3 Offset = new Vector3(0,2,0);
    public Vector3 RandomizeIntesity = new Vector3(0.5f, 0, 0);
    public float DestroyTime = 3f;

    void Start()
    {
        Destroy(gameObject, DestroyTime);
        
        transform.localPosition += Offset;
        transform.localPosition += new Vector3(Random.Range(-RandomizeIntesity.x, RandomizeIntesity.x),
        Random.Range(-RandomizeIntesity.y, RandomizeIntesity.y),
        Random.Range(-RandomizeIntesity.z, RandomizeIntesity.z));

    }

   
}

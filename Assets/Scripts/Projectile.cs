using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The class definition for a projectile
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    /// <summary>
    /// Public fields
    /// </summary>
    public float m_Speed = 10f;   // this is the projectile's speed
    public float m_Lifespan = 3f; // this is the projectile's lifespan (in seconds)

    /// <summary>
    /// Private fields
    /// </summary>
    private Rigidbody m_Rigidbody;

    /// <summary>
    /// Message that is called when the script instance is being loaded
    /// </summary>
    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Message that is called before the first frame update
    /// </summary>
    void Start()
    {
        m_Rigidbody.AddForce(m_Rigidbody.transform.forward * m_Speed);
        Destroy(gameObject, m_Lifespan);
    }
}

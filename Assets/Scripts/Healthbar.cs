using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Healthbar : MonoBehaviour
{
    public Slider healthBar;
    PlayerMove playerHealth;



    private void Start()
    {

       playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
    }

    private void Update()
    {
        healthBar.value = playerHealth.health;
    }
}

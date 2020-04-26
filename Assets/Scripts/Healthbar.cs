using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Healthbar : MonoBehaviour
{
    public Slider healthBar;
    WallJump playerHealth;



    private void Start()
    {

       playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<WallJump>();
    }

    private void Update()
    {
        healthBar.value = playerHealth.health;
    }
}

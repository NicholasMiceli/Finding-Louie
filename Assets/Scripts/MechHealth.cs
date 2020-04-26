using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MechHealth : MonoBehaviour
{
    public Slider mechBar;
    MechMove healthB;



    private void Start()
    {

        healthB = GameObject.FindGameObjectWithTag("Seat").GetComponent<MechMove>();
    }

    private void Update()
    {
        mechBar.value = healthB.mechHealth;
    }
}

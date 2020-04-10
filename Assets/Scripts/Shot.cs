using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shot : MonoBehaviour
{

    public GameObject Bullet;
    public float speed = 100f;
    public Slider ammoMeter;
    public static int ammoTotal = 10;
    public static bool sitting;
    public bool seatTick = true;

    void Start()
    {
        
    }

    void Update()
    {
        sitting = GetInVehicle.seatCheck;
        if (sitting == true && Input.GetButtonDown("Fire") && ammoTotal <= 10 && ammoTotal > 0)
        {
            ammoTotal -= 1;
            GameObject shoot = Instantiate(Bullet, transform.position, Quaternion.identity) as GameObject;
            Rigidbody shootBody = shoot.GetComponent<Rigidbody>();
            shootBody.AddForce(Vector3.forward * speed);
            Destroy(shoot, 2.5f);

        }
        if (ammoTotal < 10  && seatTick == true)
        {
            
            StartCoroutine(Energy());
        }
        ammoMeter.value = ammoTotal;
    }



    IEnumerator Energy()
    {
        seatTick = false;
        yield return new WaitForSecondsRealtime(10);
        ammoTotal += 1;
        seatTick = true;
    }

}

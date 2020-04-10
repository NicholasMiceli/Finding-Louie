using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableVehicle : MonoBehaviour
{
    public static bool sitting;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sitting = GetInVehicle.seatCheck;
        if(sitting == true)
        {
            GetComponent<VehicleController>().enabled = true;
        }
        if(sitting == false)
        {
            GetComponent<VehicleController>().enabled = false;
        }
    }
}

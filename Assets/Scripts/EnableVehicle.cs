using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableVehicle : MonoBehaviour
{
    public static bool sitting;
    public static int gasHeight;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gasHeight = GasMeter.gasTotal;
        sitting = GetInVehicle.seatCheck;
       
       
        if(sitting == true)
        {
            GetComponent<VehicleController>().enabled = true;
            GetComponent<MechMove>().enabled = true;
            

           
        }
        if(sitting == false )
        {
            GetComponent<VehicleController>().enabled = false;
            GetComponent<MechMove>().enabled = false;

           
        }
    }
}

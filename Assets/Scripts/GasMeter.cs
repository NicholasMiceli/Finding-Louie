using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GasMeter : MonoBehaviour
{
    public Slider gasMeter;
    public static int gasTotal = 20;
    public static bool sitting;
    public bool seatTick = true;
    public int gasTotalP;
   

    void Start()
    {
      
    }
    void Update()
    {
         sitting = GetInVehicle.seatCheck;
        

         if (sitting == true && seatTick == true && gasTotal <= 20 && gasTotal > 0)
         {

            gasTotal -= 1;
            StartCoroutine(Fuel () );
            Debug.Log("Gas = " + gasTotal.ToString());

            
         }
        if (gasTotal == 0)
        {
            GetComponent<VehicleController>().enabled = false;
        }
        gasMeter.value = gasTotal;
     }
     void OnTriggerEnter(Collider other)
     {
         if (other.gameObject.CompareTag("Gascan"))
         {
             if (gasTotal < 20)
             {
                
                gasTotal = 20;

                Debug.Log("Gas = " + gasTotal.ToString());
                other.gameObject.SetActive(false);
               
            }
             
         }
     }
     IEnumerator Fuel()
     {
         seatTick = false;
         yield return new WaitForSecondsRealtime(5);
         seatTick = true;
     }
    
}

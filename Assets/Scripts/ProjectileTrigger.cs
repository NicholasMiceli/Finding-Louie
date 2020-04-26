using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// The class definition for a projectile's trigger
/// </summary>
/// <remarks>
/// Attach this script as a component to any object capable of triggering projectiles
/// The spawn transform should represent the position where the projectile is to appear, i.e. gun barrel end
/// </remarks>
public class ProjectileTrigger : MonoBehaviour
{
    /// <summary>
    /// Public fields
    /// </summary>
    public Slider ammoMeter;
    public int ammoTotal = 10;
    public static bool sitting;
    public bool seatTick = true;
    public GameObject m_Projectile;    // this is a reference to your projectile prefab
    public Transform m_SpawnTransform; // this is a reference to the transform where the prefab will spawn

    /// <summary>
    /// Message that is called once per frame
    /// </summary>
    private void Update()
    {

        sitting = GetInVehicle.seatCheck;
        if (sitting == true && Input.GetKeyDown(KeyCode.Mouse0) && ammoTotal <= 10 && ammoTotal > 0)
        {
            Instantiate(m_Projectile, m_SpawnTransform.position, m_SpawnTransform.rotation);
            ammoTotal -= 1;
        }
        if (ammoTotal < 10 && seatTick == true)
        {

            StartCoroutine(Energy());
        }
        ammoMeter.value = ammoTotal;

    }

    IEnumerator Energy()
    {
        seatTick = false;
        yield return new WaitForSecondsRealtime(2);
        ammoTotal += 1;
        seatTick = true;
    }
}
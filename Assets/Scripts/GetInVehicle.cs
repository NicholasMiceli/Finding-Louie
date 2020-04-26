using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GetInVehicle: MonoBehaviour
{
    public GameObject seatPos;
    public static bool seatCheck = false;
    public float speed = 100f;
    private Rigidbody rb;
    public GameObject player;
    public GameObject seat;
    public GameObject camera;
    float mechRotation;
    Quaternion playerRotation;
   // public Transform launchDirection;
    //public float launchForce = 400f;
    //public float launchVelocity = 10f;
    WallJump playerController;
    
    bool flung = false;
    private GameObject newPlayer;
    private GameObject newSeat;
    private Transform newLaunch;
    private Slider newHealth;
    public GameObject healthBar;
    public GameObject gasGauge;
    public GameObject energyGauge;
    public GameObject mechHealth;
    public static int gasHeight;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        seatCheck = false;
        player = GameObject.Find("Player");
        seat = GameObject.Find("Seat");
        camera = GameObject.Find("Main Camera");

        playerController = GameObject.FindObjectOfType<WallJump>();

    }

    void Update()
    {
        gasHeight = GasMeter.gasTotal;
        if (seatCheck == true)
        {
            transform.position = seatPos.transform.position;
        }

        if (seatCheck == true && Input.GetKey("e") || gasHeight == 0)
        {

            CharacterController cc = player.GetComponent<CharacterController>();
            seatCheck = false;
            GetComponent<WallJump>().enabled = true;
            player.transform.parent = null;
            cc.enabled = true;
            healthBar.SetActive(true);
            mechHealth.SetActive(false);
            gasGauge.SetActive(false);
            energyGauge.SetActive(false);
            seat.GetComponent<MechMove>().enabled = false;
            seat.GetComponentInChildren<CameraController>().enabled = false;
            camera.GetComponentInChildren<Camera>().enabled = true;
            camera.GetComponentInChildren<CameraControls>().enabled = true;
            seat.GetComponentInChildren<Camera>().enabled = false;
            seat.GetComponent<AudioSource>().enabled = false;
            player.GetComponent<AudioSource>().enabled = true;
            player.GetComponent<WallJump>().enabled = true;
            player.transform.rotation = playerRotation;
            gameObject.transform.parent = null;
            Debug.Log("button pressed");
        }
    }



    void OnTriggerStay(Collider other)
    {
        if (seatCheck == false && other.gameObject.CompareTag("Seat"))
        {
            if (Input.GetKey("f") && gasHeight >= 1)
            {
                CharacterController cc = player.GetComponent<CharacterController>();
                seatCheck = true;
                transform.position = seatPos.transform.position;

                player.transform.parent = seat.transform;

                healthBar.SetActive(false);
                mechHealth.SetActive(true);
                gasGauge.SetActive(true);
                energyGauge.SetActive(true);

                player.GetComponent<WallJump>().enabled = false;
                camera.GetComponentInChildren<CameraControls>().enabled = false;
                seat.GetComponentInChildren<CameraController>().enabled = true;
                seat.GetComponentInChildren<Camera>().enabled = true;
                camera.GetComponentInChildren<Camera>().enabled = false;
                seat.GetComponent<AudioSource>().enabled = true;
                player.GetComponent<AudioSource>().enabled = false;
                seat.GetComponent<MechMove>().enabled = true;
                playerRotation = player.GetComponent<Transform>().rotation;
                Quaternion vector = seat.GetComponent<Transform>().rotation;
                player.transform.rotation = vector;

                cc.enabled = false;

            }
        }
        if (seatCheck == true && Input.GetKey("e") || gasHeight == 0)
        {
           
            CharacterController cc = player.GetComponent<CharacterController>();
            seatCheck = false;
            GetComponent<WallJump>().enabled = true;
            player.transform.parent = null;
            cc.enabled = true;
            healthBar.SetActive(true);
            mechHealth.SetActive(false);
            gasGauge.SetActive(false);
            energyGauge.SetActive(false);
            seat.GetComponent<MechMove>().enabled = false;
            seat.GetComponentInChildren<CameraController>().enabled = false;
            camera.GetComponentInChildren<Camera>().enabled = true;
            camera.GetComponentInChildren<CameraControls>().enabled = true;
            seat.GetComponentInChildren<Camera>().enabled = false;
            seat.GetComponent<AudioSource>().enabled = false;
            player.GetComponent<AudioSource>().enabled = true;
            player.GetComponent<WallJump>().enabled = true;
            player.transform.rotation = playerRotation;
            gameObject.transform.parent = null;
            Debug.Log("button pressed");
        }


    }
    

   

}

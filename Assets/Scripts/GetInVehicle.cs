using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInVehicle: MonoBehaviour
{
    public GameObject seatPos;
    public static bool seatCheck = false;
    private Rigidbody rb;
    public GameObject player;
    public GameObject seat;
    public GameObject camera;
    float mechRotation;
    Quaternion playerRotation;
    public Transform launchDirection;
    public float launchForce = 400f;
    public float launchVelocity = 10f;
    PlayerControls playerController;
    public GameObject test;
    public Rigidbody sphere;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        seatCheck = false;
        player = GameObject.Find("Player");
        seat = GameObject.Find("Seat");
        camera = GameObject.Find("CameraBase");
        test = GameObject.Find("Sphere");
        playerController = GameObject.FindObjectOfType<PlayerControls>();
        
    }

  void Update()
    {
        if(seatCheck == true)
        {
            transform.position = seatPos.transform.position;
        }
    }



     void OnTriggerStay(Collider other)
     {
         if (seatCheck == false && Input.GetButtonDown("Interact") && other.gameObject.CompareTag("Seat"))
         {
            seatCheck = true;
            transform.position = seatPos.transform.position;
            GetComponent<PlayerControls>().enabled = false;
            player.transform.parent = seat.transform;
            
            player.GetComponent<PlayerControls>().enabled = false;
            camera.GetComponentInChildren<CameraController>().enabled = false;
            seat.GetComponentInChildren<CameraController>().enabled = true;
            seat.GetComponentInChildren<Camera>().enabled = true;
            camera.GetComponentInChildren<Camera>().enabled = false;
            seat.GetComponent<MechMove>().enabled = true;
            playerRotation = player.GetComponent<Transform>().rotation;
            Quaternion vector = seat.GetComponent<Transform>().rotation;
            player.transform.rotation = vector;

        }
        if (seatCheck == true && Input.GetKey("e"))
        {
            seatCheck = false;
            GetComponent<PlayerControls>().enabled = true;
            player.transform.parent = null;

            seat.GetComponent<MechMove>().enabled = false;
            seat.GetComponentInChildren<CameraController>().enabled = false;
            camera.GetComponentInChildren<Camera>().enabled = true;
            camera.GetComponentInChildren<CameraController>().enabled = true;
            seat.GetComponentInChildren<Camera>().enabled = false;
            player.GetComponent<PlayerControls>().enabled = true;
            player.transform.rotation = playerRotation;
        }
        if (seatCheck == true && Input.GetButtonDown("Interact"))
        {
            
            seatCheck = false;
            GetComponent<PlayerControls>().enabled = true;
            player.transform.parent = null;
            Launch();
            seat.GetComponent<MechMove>().enabled = false;
            seat.GetComponentInChildren<CameraController>().enabled = false;
            camera.GetComponentInChildren<Camera>().enabled = true;
            camera.GetComponentInChildren<CameraController>().enabled = true;
            seat.GetComponentInChildren<Camera>().enabled = false;
            player.GetComponent<PlayerControls>().enabled = true;
            player.transform.rotation = playerRotation;

        }

        void Launch()
        {
            float launchDirX = launchDirection.position.x;
            float launchDirY = launchDirection.position.y;
            float launchDirZ = launchDirection.position.z;

            float startPointX = transform.position.x;
            float startPointY = transform.position.y;
            float startPointZ = transform.position.z;

            

            //launch direction
            Vector3 launchDir = new Vector3(launchDirX - startPointX, launchDirY - startPointY, launchDirZ - startPointZ).normalized;
            print("Launch");
            //player.GetComponent<PlayerControls>().ExitMech(launchDir, launchForce);
            print("Launch");
            sphere.AddForce(launchDir * launchForce);
        }
    }
   
}

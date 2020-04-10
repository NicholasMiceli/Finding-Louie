using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float CameraMoveSpeed = 120.0f;
    public GameObject CameraFollowObj;
    Vector3 FollowPos;
    public float clamAngle = 80.0f;
    public float inputSensitivity = 150.0f;
    public GameObject CameraObj;
    public GameObject PlayerObj;
    public float camDistanceXtoPlayer;
    public float camDistanceYtoPlayer;
    public float camDistanceZtoPlayer;
    public float mouseX;
    public float mouseY;
    public float finalInputX;
    public float finalInputY;
    public float smoothX;
    public float smoothY;
    private float rotY = 0.0f;
    private float rotX = 0.0f;

    

    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    
    void Update()
    {
        float inputX = Input.GetAxis("RightStickHorizontal");
        float inputY = Input.GetAxis("RightStickVertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        finalInputX = inputX + mouseX;
        finalInputY = inputY + mouseY;

        rotY += finalInputX * inputSensitivity * Time.deltaTime;
        rotX += finalInputY * inputSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clamAngle, clamAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;


        
    }

    private void LateUpdate()
    {
        CameraUpdate();
    }

    void CameraUpdate()
    {
        Transform target = CameraFollowObj.transform;

        float step = CameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}

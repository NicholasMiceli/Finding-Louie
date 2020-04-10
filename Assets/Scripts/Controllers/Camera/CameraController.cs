using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const float Y_ANGLE_MIN = -15.0f;
    private const float Y_ANGLE_MAX = 45.0f;

    public Transform lookAt;
    public Transform camTransform;

    private Camera cam;

    public float distance;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float SensitivityX = 0.0f;
    private float SensitivityY = 0.0f;

    public float mouseSensitivity;
    public Transform playerBody;

    

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    void Start()
    {
        camTransform = transform;
        cam = Camera.main;
    }

    void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");
        float MouseX = Input.GetAxis("Mouse X");

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);

        float rotAmountX = MouseX * mouseSensitivity;

        Vector3 targetRotBody = playerBody.rotation.eulerAngles;
        targetRotBody.y += rotAmountX;
        playerBody.rotation = Quaternion.Euler(targetRotBody);

        distance = GetComponent<CameraCollision>().distance;
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }


}
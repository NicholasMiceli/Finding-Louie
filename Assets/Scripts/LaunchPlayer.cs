using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPlayer : MonoBehaviour
{
    WallJump player;
    GameObject character;
    public Transform launchDirection;
    public float launchForce = 400f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<WallJump>();
        character = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Launch();
        }
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
        Vector3 launchDir = new Vector3(launchDirX - startPointX, launchDirY - startPointY, launchDirZ - startPointZ);
        //player.ExitMech(launchDir, launchForce);
    }
}

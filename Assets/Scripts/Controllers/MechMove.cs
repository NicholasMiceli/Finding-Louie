using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MechMove : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    public float gravity = -9.8f;
    public static bool GameIsPaused = false;
    // public GameObject pauseMenuUI;
    public GameObject healthBar;
    public static bool enemyStop = false;   
    public int health = 5;
    public bool damageTimer = true;
    public int gasTotalPlayer;
    Vector3 velocity;
    bool isGrounded;
    bool gamePaused = false;
    bool gameOver = false;
    private Vector3 moveDirection = Vector3.zero;
    //Camera cam;

    void Start()
    {
        gasTotalPlayer = GasMeter.gasTotal;
        enemyStop = false;
        controller = GetComponent<CharacterController>();
        GameObject seat = GameObject.Find("Seat");
       // cam = seat.GetComponentInChildren<Camera>();
    }

    void Update()
    {

        

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        /* if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Escape"))
         {


             if (GameIsPaused)
             {
                 Resume();
             }
             else
             {
                 Pause();
             }
         }
         */



      //  Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
      //  Vector3 planeNormal = -cam.forward;

      //  mousePos = Vector3.ProjectOnPlane(mousePos, planeNormal);
      //  Vector3 pos = Vector3.ProjectOnPlane(transform.position, planeNormal);

      //  Vector3 dir = (mousePos - pos).normalized;
      //  airMotion = dir * jumpForce;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gascan"))
        {
            if (gasTotalPlayer < 10)
            {

                gasTotalPlayer = 10;
                Debug.Log("Gas = " + gasTotalPlayer.ToString());
                other.gameObject.SetActive(false);
            }

        }
        /*
         if (other.gameObject.CompareTag("Goal"))
         {
             SceneManager.LoadScene("Win Scene");
             gameOver = true;
             if (gameOver == true)
             {
                 Cursor.visible = true;
                 Cursor.lockState = CursorLockMode.None;
             }
         }*/

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (damageTimer == true)
            {
                {
                    health -= 1;
                    StartCoroutine(Pain());
                    Debug.Log("Health = " + health.ToString());
                }
            }
            if (health == 0)
            {
                gameObject.SetActive(false);
                SceneManager.LoadScene("LoseMenu");
                gameOver = true;
                if (gameOver == true)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
            }
        }
    }


    IEnumerator Pain()
    {
        damageTimer = false;
        yield return new WaitForSecondsRealtime(1.5f);
        damageTimer = true;
    }

    /* public void Resume()
     {

         pauseMenuUI.SetActive(false);
         healthBar.SetActive(true);
         Time.timeScale = 1f;
         GameIsPaused = false;
         if(maskCheck == true)
         {
             maskIcon.SetActive(true);
         }

     }
     void Pause()

     {

         pauseMenuUI.SetActive(true);
         healthBar.SetActive(false);
         maskIcon.SetActive(false);
         Time.timeScale = 0f;
         GameIsPaused = true;


     }
     */
}
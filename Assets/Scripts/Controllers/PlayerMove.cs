using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode jumpKey2 = KeyCode.Space;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject healthBar;   
    private bool crouched = false;
    private float originalHeight;
    [SerializeField] private float crouchHeight = 0.5f;
    public KeyCode crouchKey = KeyCode.C;
    public KeyCode crouchKey2 = KeyCode.C;
   // public GameObject maskIcon;
   // public bool maskCheck = false;
    public static bool enemyStop = false;
    //public Rigidbody rb;
    public int health = 5;
    public bool damageTimer = true;
    public int gasTotalPlayer;
    public Transform groundCheck;
    public float groundDistance = .4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;
    bool gamePaused = false;
    bool gameOver = false;
    private Vector3 moveDirection = Vector3.zero;
    bool onWall = false;
    bool canJump = false;
    Vector3 groundedVelocity;
    Vector3 normal;
    float verticalVelocity;
    public float airSpeed;
  
    

    void Start()
    {
        gasTotalPlayer = GasMeter.gasTotal;
        enemyStop = false;
        controller = GetComponent<CharacterController>();
        originalHeight = controller.height;
    }

    void Update()
    {
        Vector3 myVector = Vector3.zero;

        /*   if (Input.GetKeyDown(crouchKey) || Input.GetKeyDown(crouchKey2))
            {
                crouched = !crouched;

                CheckCrouch();
            }
            */

        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        

        //if (isGrounded && velocity.y < 0)
        //{
        //    velocity.y = -2f;
        //}

        Vector3 input = Vector3.zero;
        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * input.x + transform.forward * input.z;
        controller.Move(move * speed * Time.deltaTime);


        if ((Input.GetKeyDown(jumpKey) || Input.GetKeyDown(jumpKey2)) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            
        }


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

    }

    void CheckCrouch()
    {
        if (crouched == true)
        {
            controller.height = crouchHeight;
            speed = speed / 2;
        }
        else
        {
            controller.height = originalHeight;
            if (speed != 12)
            {
                speed = 12;
            }
        }
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
       
         if (other.gameObject.CompareTag("Goal"))
         {
             SceneManager.LoadScene("WinMenu");
             gameOver = true;
             if (gameOver == true)
             {
                 Cursor.visible = true;
                 Cursor.lockState = CursorLockMode.None;
             }
         }

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

   public void Resume()
    {

        pauseMenuUI.SetActive(false);
        healthBar.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
       

    }
    void Pause()

    {

        pauseMenuUI.SetActive(true);
        healthBar.SetActive(false);
      
        Time.timeScale = 0f;
        GameIsPaused = true;


    }
    
}
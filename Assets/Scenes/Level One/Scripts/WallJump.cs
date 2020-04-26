using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WallJump : MonoBehaviour
{

    public CharacterController controller;
    public float Speed = 3f;
    public float gravityStrength = 5f;
    public float jumpSpeed = 10f;
    public float aerialSpeed = 2;
    public Transform camTransform;
    bool canJump = false;
    bool onWall = false;
    float verticalVelocity;
    Vector3 velocity;
    Vector3 groundedVelocity;
    Vector3 normal;
    public static int gasTotalPlayer;
    bool gamePaused = false;
    bool gameOver = false;
    public bool damageTimer = true;
    public int health = 5;
    public GameObject pauseMenuUI;
    public GameObject healthBar;
    public static bool GameIsPaused = false;

    public Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        gasTotalPlayer = GasMeter.gasTotal;

        Vector3 myVector = new Vector3(0, 0, 0);

        Vector3 input = Vector3.zero;
        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");
        input = Vector3.ClampMagnitude(input, 1f);

        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("Level Two");
        }

        if (controller.isGrounded)
        {
            myVector = input;
            Quaternion inputRotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(camTransform.forward, Vector3.up), Vector3.up);
            myVector = inputRotation * myVector;
            myVector *= Speed;

            


        }
        else
        {
            myVector = groundedVelocity;
            myVector += input * aerialSpeed;
        }

        if (input == Vector3.zero)
        {
            playerAnim.SetBool("isPlayerIdle", true);
            playerAnim.SetBool("isPlayerRunning", false);
            playerAnim.SetBool("isPlayerJumping", false);
            playerAnim.SetBool("isPlayerSneaking", false);

        }
        else
        {
            playerAnim.SetBool("isPlayerIdle", false);
            playerAnim.SetBool("isPlayerRunning", true);
            playerAnim.SetBool("isPlayerJumping", false);
            playerAnim.SetBool("isPlayerSneaking", false);
        }


        myVector = Vector3.ClampMagnitude(myVector, Speed);
        myVector = myVector * Time.deltaTime;


        verticalVelocity = verticalVelocity - gravityStrength * Time.deltaTime;
        if (Input.GetButtonDown("Jump"))
        {
            if (onWall)
            {
                groundedVelocity = Vector3.Reflect(velocity, normal);

                playerAnim.SetBool("isPlayerIdle", false);
                playerAnim.SetBool("isPlayerRunning", true);
                playerAnim.SetBool("isPlayerJumping", false);
                playerAnim.SetBool("isPlayerSneaking", false);
            }

            if (canJump)
            {
                verticalVelocity += jumpSpeed;

                playerAnim.SetBool("isPlayerIdle", false);
                playerAnim.SetBool("isPlayerRunning", false);
                playerAnim.SetBool("isPlayerJumping", true);
                playerAnim.SetBool("isPlayerSneaking", false);
            }

            if (controller.isGrounded)
            {
                playerAnim.SetBool("isPlayerIdle", false);
                playerAnim.SetBool("isPlayerRunning", false);
                playerAnim.SetBool("isPlayerJumping", true);
                playerAnim.SetBool("isPlayerSneaking", false);
            }


        }
        myVector.y = verticalVelocity * Time.deltaTime;

        CollisionFlags flags = controller.Move(myVector);
        velocity = myVector / Time.deltaTime;

        if ((flags & CollisionFlags.Below) != 0)
        {
            groundedVelocity = Vector3.ProjectOnPlane(velocity, Vector3.up);
            canJump = true;
            onWall = false;
            verticalVelocity = -3f;
        }
        else if ((flags & CollisionFlags.Sides) != 0)
        {
            canJump = true;
            onWall = true;
        }
        else
        {
            canJump = false;
            onWall = false;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        normal = hit.normal;
    }


    void OnTriggerEnter(Collider other)
    {
       

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

        if (other.gameObject.CompareTag("TutorialGoal"))
        {
            SceneManager.LoadScene("Level One");
        }

        if (other.gameObject.CompareTag("LeveloneGoal"))
        {
            SceneManager.LoadScene("Level Two");
        }

        if (other.gameObject.CompareTag("LeveltwoGoal"))
        {
            SceneManager.LoadScene("LevelThree");
        }

        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            health -= 1;
            other.gameObject.SetActive(false);
            Debug.Log("Health = " + health.ToString());

            if (health == 0)
            {
                gameObject.SetActive(false);
                Debug.Log("ouch");
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

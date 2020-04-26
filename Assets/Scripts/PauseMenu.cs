using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject healthBar;
    public GameObject mechHealth;
    public GameObject ammoEnergy;
    public GameObject mechFuel;
    public bool sitDown;
    public static bool playerMove;


    private void Start()
    {
        GameObject thePlayer = GameObject.Find("Player");
        WallJump playerMove = thePlayer.GetComponent<WallJump>();
        GetInVehicle.seatCheck = false;
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Escape"))
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
    }

    public void Resume()
    {
        
        pauseMenuUI.SetActive(false);
        healthBar.SetActive(true);
      
        if (GetInVehicle.seatCheck == true)
        {
            healthBar.SetActive(false);
            mechFuel.SetActive(true);
            mechHealth.SetActive(true);
            ammoEnergy.SetActive(true);
        }
      
        Time.timeScale = 1f;
        GameIsPaused = false;


    }
    void Pause()

    {
       
        pauseMenuUI.SetActive(true);
        healthBar.SetActive(false);
        if (GetInVehicle.seatCheck == false)
        {
            
            mechFuel.SetActive(false);
            mechHealth.SetActive(false);
            ammoEnergy.SetActive(false);
        }

        Time.timeScale = 0f;
        GameIsPaused = true;
        
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
        Debug.Log("Hello??");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Lo??");
    }

   
}
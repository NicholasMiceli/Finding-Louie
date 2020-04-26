using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoPlay : MonoBehaviour
{

    public int delay = 50;
    public string NewLevel = "MainMenu";


    void Start()
    {
        StartCoroutine(LoadLevelAfterDelay(delay));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
         SceneManager.LoadScene(NewLevel);
        }
    }
    
    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(NewLevel);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCredit : MonoBehaviour
{
    public float delay = 5;
    public string NewLevel= "Credits";
    void Start()
    {
        StartCoroutine(LoadLevelAfterDelay(delay));
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(NewLevel);
    }

}

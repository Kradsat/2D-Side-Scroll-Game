using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public Animator transitionScene;
    public Animator transitionDoor;

    public float transitionTime = 1f;
    public void Play()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        

    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("quit");
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transitionScene.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }

    public void BackToTitle()
    {
         StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex -2));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public void LoadNextLevel(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }

    public void ExitGame()
    {
        StartCoroutine(ExitTheGame());
    }

    IEnumerator LoadLevel(string scene)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(scene);
    }

    IEnumerator ExitTheGame()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        Application.Quit();
    }
}

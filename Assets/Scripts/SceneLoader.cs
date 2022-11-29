using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] int waitTime = 2;
    int currentSceneIndex;
    bool game = true;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(waitTime);
        LoadNextScene();
    }
    public void LoadStartMenu()
    {
        SceneManager.LoadScene("Start Scene");
    }

    public void Play()
    {
        SceneManager.LoadScene("Game Scene");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game Scene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void GameOver()
    {
        game = false;
        SceneManager.LoadScene("Game Over Scene");
    }

    public void Win()
    {
        SceneManager.LoadScene("Win Scene");
    }

    public void Story()
    {
        SceneManager.LoadScene("Story Scene");
    }

    public void Help()
    {
        SceneManager.LoadScene("Help Scene");
    }

    public bool GetGameStatus()
    {
        return game;
    }
}

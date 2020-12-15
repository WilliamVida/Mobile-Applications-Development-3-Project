using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{

    public PlayableDirector director;
    public GameObject endScreen;

    void OnEnable()
    {
        director.stopped += OnPlayableDirectorStopped;
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (director == aDirector)
        {
            AudioListener.pause = true;
            endScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void OnDisable()
    {
        director.stopped -= OnPlayableDirectorStopped;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    public void QuitGame()
    {
        Debug.Log("Quit game.");
        Application.Quit();
    }

}

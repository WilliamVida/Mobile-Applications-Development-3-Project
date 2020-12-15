using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class CollisionHandler : MonoBehaviour
{

    float levelLoadDelay = 1.0f;
    [SerializeField] GameObject explosionFX;

    CheckpointTracker checkpointTracker;
    PlayableDirector playableDirector;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint") || other.gameObject.CompareTag("Laser Bullet") || other.gameObject.CompareTag("Player"))
        {

        }
        else
        {
            Debug.Log("Death");
            Destroy(GameObject.FindWithTag("Player"));
            StartDeathSequence();
            Invoke("ResetPlayer", levelLoadDelay);
        }
    }

    private void ResetPlayer()
    {
        if (checkpointTracker == null)
        {
            checkpointTracker = GetComponent<CheckpointTracker>();
        }
        print("Last checkpoint was " + checkpointTracker);
        GameObject.Find("Player Rig").transform.position = checkpointTracker.lastCP.transform.position;
        GameObject.Find("Player Rig").transform.rotation = checkpointTracker.lastCP.transform.rotation;

        if (playableDirector == null)
        {
            playableDirector = GameObject.Find("Main Timeline").GetComponent<PlayableDirector>();
        }
        playableDirector.Pause();
        playableDirector.time = checkpointTracker.directorTime;
        playableDirector.Resume();
    }

    private void StartDeathSequence()
    {
        explosionFX.SetActive(true);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }

}

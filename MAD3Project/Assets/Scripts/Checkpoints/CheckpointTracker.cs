using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CheckpointTracker : MonoBehaviour
{

    public int lap = 0;
    public int checkpoint = 0;
    int checkpointCount;
    int nextCheckpoint;

    public GameObject lastCP;
    public double directorTime;
    PlayableDirector playableDirector;

    void Start()
    {
        checkpointCount = GameObject.FindGameObjectsWithTag("Checkpoint").Length;
        playableDirector = GameObject.Find("Main Timeline").GetComponent<PlayableDirector>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Checkpoint")
        {
            int thisCPNumber = int.Parse(other.gameObject.name);

            if (thisCPNumber == nextCheckpoint)
            {
                lastCP = other.gameObject;
                checkpoint = thisCPNumber;
                directorTime = playableDirector.time;

                if (checkpoint == 0)
                {
                    lap++;
                }

                nextCheckpoint++;

                if (nextCheckpoint >= checkpointCount)
                {
                    nextCheckpoint = 0;
                }
            }
        }
    }

}

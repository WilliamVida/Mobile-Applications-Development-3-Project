using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI lapCPText;
    CheckpointTracker checkpointTracker;

    void Update()
    {
        if (checkpointTracker == null)
        {
            checkpointTracker = GetComponent<CheckpointTracker>();
        }
        // Debug.Log("Lap: " + checkpointTracker.lap + "\nCheckpoint: " + checkpointTracker.checkpoint);
        lapCPText.text = "Lap: " + checkpointTracker.lap + "\nCheckpoint: " + checkpointTracker.checkpoint;
    }

}

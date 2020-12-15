using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SetCheckpointNumbers : MonoBehaviour
{

    private void Awake()
    {
        Transform[] checkpoints = this.GetComponentsInChildren<Transform>();
        int number = 0;

        foreach (var cp in checkpoints)
        {
            if (cp.gameObject != this.gameObject)
            {
                cp.gameObject.name = "" + number;
                number++;
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRig : MonoBehaviour
{

    GameObject[] players;
    bool playersAreSet = false;

    void LateUpdate()
    {
        if (playersAreSet) return;
        Transform parent = gameObject.GetComponent<Transform>();
        Vector3 startPosition = parent.transform.position + new Vector3(0, -6, 40);
        Vector3 adjustment;
        Vector3[] startPos = new[] { new Vector3(-6f, -2f, 12f), new Vector3(6f, -2f, 12f) };

        // get the "player" tag objects and set their parents to the camera
        players = GameObject.FindGameObjectsWithTag("Player");
        print("there are ships of " + players.Length);

        for (int i = 0; i < players.Length; i++)
        {
            adjustment = new Vector3(5 - (10 * i), 0, 0);
            players[i].transform.SetParent(parent);
            players[i].transform.position = parent.transform.position + startPos[i];
            players[i].transform.rotation = parent.transform.rotation;
        }

        playersAreSet = true;
    }

}

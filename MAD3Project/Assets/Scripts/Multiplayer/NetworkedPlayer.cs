using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class NetworkedPlayer : MonoBehaviourPunCallbacks
{

    public static GameObject LocalPlayerInstance;
    // public GameObject PlayerNamePrefab;
    public Rigidbody rb;

    private void Awake()
    {
        // if (photonView.IsMine)
        // {
        //     LocalPlayerInstance = gameObject;
        // }
        // else
        // {
        //     // set up the player name on the this instance - networked instance to be updated.
        //     GameObject playerName = Instantiate(PlayerNamePrefab);
        //     // playerName.GetComponent<NameUIController>().target = rb.gameObject.transform;
        //     // playerName.GetComponent<Text>().text = photonView.Owner.NickName;
        // }
    }

}

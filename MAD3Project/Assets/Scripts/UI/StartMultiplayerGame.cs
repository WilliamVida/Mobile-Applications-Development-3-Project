using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Photon.Realtime;
using Photon.Pun;

public class StartMultiplayerGame : MonoBehaviour
{

    [SerializeField] GameObject[] PlayerShipPrefabs;
    [SerializeField] GameObject startButton;
    [SerializeField] float levelStartDelay = 1.5f;

    private int currentShip = 0;
    private PlayableDirector pd;

    void Start()
    {
        GameObject playerShip = null;
        Transform parent = GameObject.Find("Player Rig").GetComponent<Transform>();
        Vector3 startPosition = parent.transform.position + new Vector3(0, -5, 30);
        Quaternion startRotation = parent.transform.rotation;

        startButton.SetActive(false);

        if (PhotonNetwork.IsConnected)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount > 1)
            {

            }
            if (NetworkedPlayer.LocalPlayerInstance == null)
            {

            }
            if (PhotonNetwork.IsMasterClient)
            {
                AudioListener.pause = true;
                Time.timeScale = 0f;
                startButton.SetActive(true);
            }
        }
        else
        {
            // playerShip = Instantiate(PlayerShipPrefabs[currentShip]);
            // playerShip.transform.SetParent(parent);
            // playerShip.transform.position = startPosition;
            // playerShip.transform.rotation = startRotation;
            // Invoke("StartTheLevel", levelStartDelay);
        }
    }


    public void StartMultiPlayerGame()
    {
        StartTheLevel();
        startButton.SetActive(false);
    }

    private void StartTheLevel()
    {
        pd = GameObject.Find("Main Timeline").GetComponent<PlayableDirector>();
        pd.Play();
    }

}

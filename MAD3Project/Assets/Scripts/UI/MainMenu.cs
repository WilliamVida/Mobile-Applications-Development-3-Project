using Photon.Realtime;
using Photon.Pun;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviourPunCallbacks
{

    [SerializeField] TextMeshProUGUI playerName;

    byte maxPLayersPerRoom = 4;
    bool isConnecting;
    public TextMeshProUGUI feedbackText;
    string gameVersion = "1";

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            // if (NetworkedPlayer.LocalPlayerInstance == null)    // instantiate the networked prefabs
            // {
            //     playerShip = PhotonNetwork.Instantiate(PlayerShipPrefabs[currentShip].name,
            //                                             startPosition, startRotation, 0);
            // }
        }

        if (PlayerPrefs.HasKey("PlayerShip"))
        {
            //currentShip = PlayerPrefs.GetInt("PlayerShip");
            playerName.text = PlayerPrefs.GetString("PlayerName");
        }
    }

    public void SetPlayerName(string name)
    {
        //print("LabLaunchManager : Set player name " + name);
        PlayerPrefs.SetString("PlayerName", name);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayMultiplayer()
    {
        feedbackText.text = "";
        isConnecting = true;

        if (PhotonNetwork.IsConnected)
        {
            feedbackText.text = "\nJoining a room...";
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            feedbackText.text += "\nConnecting to network...";
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        if (isConnecting)
        {
            feedbackText.text += "\nConnected, joining room...";
            PhotonNetwork.JoinRandomRoom();
        }
    }

    public override void OnJoinRandomFailed(short ReturnCode, string Message)
    {
        feedbackText.text += "\nFailed to join random room...";
        feedbackText.text += "\nCreating a new room...";
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = this.maxPLayersPerRoom });
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        feedbackText.text += "\nDisconnected: " + cause;
        isConnecting = false;
    }

    public override void OnJoinedRoom()
    {
        feedbackText.text += "\nSuccessfully joined room, game starting...";
        feedbackText.text += "\nNumber of players: " + PhotonNetwork.CurrentRoom.PlayerCount + " players.";
        PhotonNetwork.LoadLevel(1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game.");
        Application.Quit();
    }

}

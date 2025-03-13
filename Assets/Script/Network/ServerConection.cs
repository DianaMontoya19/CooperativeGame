using UnityEngine;
using Photon.Pun;

public class ServerConection : MonoBehaviourPunCallbacks
{
 // proceso de conexion   
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnected()
    {
        base.OnConnected();
        Debug.Log(" Is Connected");

    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Is connected Master");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();

        Debug.Log("Has Join");
    }

}

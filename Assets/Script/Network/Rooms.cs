using Photon.Pun;
using TMPro;
using UnityEngine;


public class Rooms : MonoBehaviourPunCallbacks
{
    //[SerializeField] private string roomName;

    //[ContextMenu("Create")]
    //public void CreateToRooms()
    //{
    //    PhotonNetwork.CreateRoom(roomName);
    //}

    //[ContextMenu("Join")]
    //public void JoinRoom()
    //{
    //    PhotonNetwork.JoinRoom(roomName);
    //}
    //public override void OnJoinedLobby()
    //{
    //    base.OnJoinedLobby();

    //    Debug.Log("Has Connected To room");
    //}
    //public override void OnJoinRoomFailed(short returnCode, string message)
    //{
    //    base.OnJoinRoomFailed(returnCode, message);
    //    Debug.Log($"Room Connection fail! \nCode: {returnCode} Error: {message}");
    //}


    [SerializeField] private TMP_InputField joinInputField, createInputField;
    [SerializeField] private string roomName;

    private void Start()
    {
        joinInputField?.onValueChanged.AddListener(text => { roomName = text; });
        createInputField?.onValueChanged.AddListener(text => { roomName = text; });
    }

    [ContextMenu("Create")]
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(roomName);
    }

    [ContextMenu("Join")]
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    [ContextMenu("Leave")]
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        print("Room Created!");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        print($"Room Connection Failed!\nCode: {returnCode}, Error: {message}");
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print($"Has Connected To Room{PhotonNetwork.CurrentRoom.Name}!");
        PhotonNetwork.LoadLevel("Game");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        print($"Room Connection Failed!\nCode: {returnCode}, Error: {message}");
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        print($"Has Left The Room!");
    }
}


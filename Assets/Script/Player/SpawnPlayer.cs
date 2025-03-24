using System.Collections;
using NUnit.Framework;
using Photon.Pun;
using System.Collections.Generic;
using Script.Lever;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] List<Transform> spawnPosition = new List<Transform>();
    [SerializeField] List<GameObject> player = new List<GameObject>();
    
    void Start()
    {
        int playerIndex = PhotonNetwork.CurrentRoom.PlayerCount - 1;
        GameObject playerClone = PhotonNetwork.Instantiate(player[playerIndex].name, spawnPosition[playerIndex].position, Quaternion.identity);
        playerClone.name = "Player" + PhotonNetwork.LocalPlayer.ActorNumber.ToString();
        
    }




}

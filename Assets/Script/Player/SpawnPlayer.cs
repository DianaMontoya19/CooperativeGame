using NUnit.Framework;
using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] List<Transform> spawnPosition = new List<Transform>();
    [SerializeField] List<GameObject> player = new List<GameObject>();
    
    void Start()
    {
        int playerIndex = PhotonNetwork.CurrentRoom.PlayerCount - 1;
        PhotonNetwork.Instantiate(player[playerIndex].name, spawnPosition[playerIndex].position, Quaternion.identity);
    }

    
}

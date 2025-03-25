using System;
using System.Collections.Generic;
using Photon.Pun;
using Script.Lever;
using UnityEngine;

namespace Script.Gems
{
    public class Door : MonoBehaviourPunCallbacks
    {
        public SpriteRenderer door;
        public bool activePlayer1;
        public static Door Instance;
        
        private void Start()
        {
            Instance = this;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
           if (other.gameObject.CompareTag("Player"))
           {
               LeverController.Instance.player1Active = true;
              
               photonView.RPC("ChangeDoorColor", RpcTarget.All);
                int playerViewID = other.gameObject.GetComponent<PhotonView>().ViewID;
                DestroyPlayer(playerViewID);
                
           }
        }
        [PunRPC]
        private void ChangeDoorColor()
        {
            door.color = Color.black;
        }
        [PunRPC]
        private void DestroyPlayer(int playerViewID)
        {
            PhotonView playerPhotonView = PhotonView.Find(playerViewID);
            if (playerPhotonView != null)
            {
                PhotonNetwork.Destroy(playerPhotonView.gameObject);
                
            }
        }
       
    }
}
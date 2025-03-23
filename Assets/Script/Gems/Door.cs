using System;
using Photon.Pun;
using UnityEngine;

namespace Script.Gems
{
    public class Door : MonoBehaviourPunCallbacks
    {
        public string player;
        public SpriteRenderer door;
        public int detectedPlayer;
        public static Door Instance;

        private void Start()
        {
            Instance = this;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
           if (other.gameObject.CompareTag(player))
           {
                    photonView.RPC("ChangeDoorColor", RpcTarget.All);
                    Debug.Log("detecto player");
                    detectedPlayer = 1;
                    photonView.RPC("DestroyPlayer", RpcTarget.All, other.gameObject.GetComponent<PhotonView>().ViewID);
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
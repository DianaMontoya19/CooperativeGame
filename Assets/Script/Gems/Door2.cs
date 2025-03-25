using System;
using System.Collections;
using UnityEngine;
using Photon.Pun;
using Script.Lever;

namespace Script.Gems
{
    public class Door2 : MonoBehaviourPunCallbacks
    {
        public bool activePlayer2;
        public static Door2 Instance;

        private void Start()
        {
            Instance = this;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player2"))
            {
                LeverController.Instance.player2Active = true;
                StartCoroutine(TimeToDead(other));
            }
            
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

        IEnumerator TimeToDead(Collider2D other)
        {
            yield return new WaitForSeconds(0.5f);
            int playerViewID = other.gameObject.GetComponent<PhotonView>().ViewID;
            DestroyPlayer(playerViewID);
        }
        
    }
}
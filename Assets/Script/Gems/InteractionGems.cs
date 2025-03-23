using System;
using Photon.Pun;
using Unity.Mathematics;
using UnityEngine;

namespace Script.Gems
{
    public class InteractionGems : MonoBehaviourPunCallbacks
    {
        public string namePlayer;
        [SerializeField] private GameObject door;
        [SerializeField] private Vector3 doorPosition;
        private bool doorInstantiated = false; 
        public void OnTriggerEnter2D(Collider2D other)
        {
           if (other.gameObject.CompareTag(namePlayer) && !doorInstantiated)
           {
               PhotonNetwork.Instantiate(door.name, doorPosition, quaternion.identity);
               doorInstantiated = true;
            }

            Destroy(gameObject);
            
        }
    }
}
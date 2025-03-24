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
        public int count = 0;
        public void OnTriggerEnter2D(Collider2D other)
        {
           if (other.gameObject.CompareTag(namePlayer) && !doorInstantiated)
           {
               Spawn();
           }
            
            Destroy(gameObject);
            
        }

        public void Spawn()
        {
            Instantiate(door, doorPosition, quaternion.identity);
            doorInstantiated = true; 
        }
    }
}
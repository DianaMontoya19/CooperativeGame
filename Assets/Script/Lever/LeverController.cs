
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Script.Platform;
using UnityEngine;

namespace Script.Lever
{
    public class LeverController : MonoBehaviourPunCallbacks
    {
        public static LeverController Instance;
        public bool platformActive, blockActive, player1Active , player2Active;
        public GameObject[] _obstacle;
        public GameObject win;
        public int countPlayer;
        private GameObject player, player2;
        public List<int> playerID = new List<int>();
        private PhotonView photonView;

        private void Start()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject); // Asegurarse de que solo haya una instancia
            }

            photonView = GetComponent<PhotonView>(); // Obtener el PhotonView
            platformActive = false;
            player1Active = false;
            player2Active = false;
   
        }

        private void Update()
        {
            if (platformActive)
            {
                _obstacle[0].GetComponent<InteractPlatform>().GetAnim();
            }

            if (blockActive)
            {
                _obstacle[1].GetComponent<InteractPlatform>().GetAnim();
            }
        }




    }
  
    //         player = GameObject.Find("Player1");
    //         player2 = GameObject.Find("Player2");
    //
    //
    //     }
    //
    //     public void Update()
    //     {
    //        
    //         if (platformActive)
    //         {
    //             _obstacle[0].GetComponent<InteractPlatform>().GetAnim();
    //            
    //         }
    //         if (blockActive)
    //         {
    //             _obstacle[1].GetComponent<InteractPlatform>().GetAnim();
    //            
    //         }
    //
    //         if (player == null)
    //         {
    //             player1Active = true;
    //         }
    //
    //         if (player2 == null)
    //         {
    //             player2Active = true;
    //         }
    //
    //         if (player1Active && player2Active)
    //         {
    //             win.SetActive(true);
    //         }
    //
    //         
    //     }
    //     public void AddPlayer(int playerViewID)
    //     {
    //         playerID.Add(playerViewID);
    //         Debug.Log("Jugador añadido: " + playerViewID);
    //     }
    //     public void RemovePlayer(int playerViewID)
    //     {
    //         playerID.Remove(playerViewID);
    //         Debug.Log("Jugador eliminado: " + playerViewID);
    //         
    //     }
    //     
    //
    //    
    // }
}
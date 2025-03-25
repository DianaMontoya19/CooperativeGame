using Photon.Pun;
using Script.Platform;
using UnityEngine;

namespace Script.Lever
{
    public class LeverController : MonoBehaviourPunCallbacks
    {
        public static LeverController Instance;
        public bool platformActive, blockActive, player1Active, player2Active;
        public GameObject[] _obstacle;
        public GameObject win, canvas;
        public int countPlayer;
        // private PhotonView photonView;

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

            // photonView = GetComponent<PhotonView>();

            
            // win = PhotonNetwork.Instantiate("WinPrefab", canvas.transform.position, Quaternion.identity);
            // win.transform.SetParent(canvas.transform);
            // win.SetActive(false); 
            
            
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

                if (player1Active && player2Active)
                {

                    activar();
                }
            

        }
        public void activar()
        {
            photonView.RPC("ActivateWin", RpcTarget.All);
        }
        [PunRPC]
        public void ActivateWin()
        {
            if (win != null)
            {
                win.SetActive(true); 
            }
            else
            {
                Debug.LogError("El objeto 'win' es NULL.");
            }
            
        }

        

    }

}
using Photon.Pun;
using UnityEngine;

namespace Script.Platform
{
    public class InteractPlatform : MonoBehaviourPunCallbacks
    {
        public bool activatePlatform;
        [SerializeField] private Animator anim;

        public void GetAnim()
        {
            // ActivateAnim();
            photonView.RPC("ActivateAnim", RpcTarget.All);
            
        }
        [PunRPC]
        public void ActivateAnim()
        {
            anim.enabled = true;
        }
    }
}
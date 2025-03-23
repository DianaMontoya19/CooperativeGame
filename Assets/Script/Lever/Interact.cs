using System;
using Photon.Pun;
using Unity.Netcode;
using UnityEngine;
using RpcTarget = Photon.Pun.RpcTarget;

public class Interact : MonoBehaviourPunCallbacks
{

    private Animator anim;
    public string namePlayer;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(namePlayer))
        {
           
            photonView.RPC("ActivateLever", RpcTarget.All);
        }
    }
    [PunRPC]
    public void ActivateLever()
    {
        anim.SetBool("LeverActive", true);
        Debug.Log("Activar palanca");
    }
}



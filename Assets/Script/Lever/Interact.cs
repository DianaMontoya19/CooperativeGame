using System;
using Photon.Pun;
using UnityEngine;

public class Interact : MonoBehaviourPunCallbacks
{

    private Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ActivateLever();
            // if (photonView.IsMine)
            // {
            //     photonView.RPC("ActivateLever", RpcTarget.All);
            // }
        }
    }
    void ActivateLever()
    {
        anim.SetBool("LeverActive", true);
        Debug.Log("Activar palanca");
    }
}



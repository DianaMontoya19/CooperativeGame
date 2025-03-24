using System;
using System.Collections;
using Photon.Pun;
using Script.Gems;
using Script.Lever;
using Script.Platform;
using UnityEngine;

public class PlayerController : MonoBehaviourPunCallbacks
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sp;
    [SerializeField] private float speed, jumpForce;
    [SerializeField] private string detectionPlayer;
    private Vector2 savePoint;
    public int detectedPlayer = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        savePoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");

            rb.linearVelocity = new Vector2(moveHorizontal * speed, rb.linearVelocity.y);

            if (moveHorizontal > 0)
            {
                sp.flipX = false;
                anim.SetBool("Walk", true);
            }
            else if(moveHorizontal < 0)
            {
                sp.flipX = true;
                anim.SetBool("Walk", true);
            }
            else if(moveHorizontal ==0)
            {
                anim.SetBool("Walk", false);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
            if (other.gameObject.CompareTag("Platform"))
            {

                LeverController.Instance.platformActive = true;

            }

            if (other.gameObject.CompareTag("block"))
            {

                LeverController.Instance.blockActive = true;

            }

            if (other.gameObject.CompareTag(detectionPlayer))
            {
                StartCoroutine(TimeToReset());
                Debug.Log("moriste");
            }
        
    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("Door"))
    //     {
    //         detectedPlayer++;
    //         
    //     }
    // }

    IEnumerator TimeToReset()
    {
        GetComponent<SpriteRenderer>().color = Color.black;
        yield return new WaitForSeconds(1f);
        transform.position= savePoint;
        GetComponent<SpriteRenderer>().color = Color.white;
        
    }
}

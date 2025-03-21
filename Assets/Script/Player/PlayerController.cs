using System;
using System.Collections;
using Photon.Pun;
using Script.Platform;
using UnityEngine;

public class PlayerController : MonoBehaviourPunCallbacks
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sp;
    [SerializeField] private float speed, jumpForce;
    private GameObject platform;
    [SerializeField] private string detectionPlayer;
    private Vector2 savePoint;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        platform = FindObjectOfType<InteractPlatform>().gameObject;
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
            platform.GetComponent<InteractPlatform>().ActivateAnim();

        }

        if (other.gameObject.CompareTag("block"))
        {
            platform.GetComponent<InteractPlatform>().ActivateAnim();
            
        }
        if (other.gameObject.CompareTag(detectionPlayer))
        {
            StartCoroutine(TimeToReset());
            Debug.Log("moriste");
        }
    }

    IEnumerator TimeToReset()
    {
        GetComponent<SpriteRenderer>().color = Color.black;
        yield return new WaitForSeconds(1f);
        transform.position= savePoint;
        GetComponent<SpriteRenderer>().color = Color.white;
        
    }
}

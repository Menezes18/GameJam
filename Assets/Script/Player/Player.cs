using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;


    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public Animator clip;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
        if (Mathf.Abs(horizontal) > 0.1f)
        {
            Debug.Log("A");
            clip.SetBool("Run", true);
        }
        else
        {
            clip.SetBool("Run", false);
        }
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        Collider[] colliders = new Collider[1];
        int count = Physics.OverlapSphereNonAlloc(groundCheck.position, 0.2f, colliders, groundLayer);

        return count > 0;
    }


    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "CheckPoint")
        {
            GameController.Instance.Check1 = true;
        }
        if (other.gameObject.tag == "CheckPoint1")
        {
            GameController.Instance.Check2 = true;
        }
        if (other.gameObject.tag == "CheckPoint2")
        {
            GameController.Instance.Check2 = true;
        }
        if (other.gameObject.tag == "CheckPoint3")
        {
            GameController.Instance.Check2 = true;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "SafeCheck")
        {
            GameController.Instance.SafeCheck1 = true;
            
        }
        if (other.gameObject.tag == "SafeCheck1")
        {
            GameController.Instance.SafeCheck2 = true;
            
        }
        if (other.gameObject.tag == "SafeCheck2")
        {
            GameController.Instance.SafeCheck3 = true;
            
        }
        if (other.gameObject.tag == "SafeCheck3")
        {
            GameController.Instance.SafeCheck4 = true;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "SafeCheck")
        {
            GameController.Instance.SafeCheck1= false;

        }
        if (other.gameObject.tag == "SafeCheck1")
        {
            GameController.Instance.SafeCheck2= false;

        }
        if (other.gameObject.tag == "SafeCheck2")
        {
            GameController.Instance.SafeCheck3= false;

        }
        if (other.gameObject.tag == "SafeCheck3")
        {
            GameController.Instance.SafeCheck4= false;

        }
    }
    
}
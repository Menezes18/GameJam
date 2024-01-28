using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;
    public float pushForce = 5f;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public Animator clip;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space)  && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryPushObject(); // Método para tentar empurrar um objeto
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
    private void TryPushObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 1.0f))
        {
            if (hit.collider.CompareTag("PushableObject"))
            {
                Rigidbody objectRb = hit.collider.GetComponent<Rigidbody>();
                if (objectRb != null)
                {
                    objectRb.AddForce(Vector3.right * pushForce, ForceMode.Impulse);
                }
            }
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
            DiminuirEscala.instancia.IniicoShader = false;
            GameController.Instance.Check1 = true;
            DiminuirEscala.instancia.ReiniciarV();
        }
        if (other.gameObject.tag == "CheckPoint1")
        {
            GameController.Instance.Check2 = true;
            DiminuirEscala.instancia.ReiniciarV();
        }
        if (other.gameObject.tag == "CheckPoint2")
        {
            GameController.Instance.Check3 = true;
            DiminuirEscala.instancia.ReiniciarV();
        }
        if (other.gameObject.tag == "CheckPoint3")
        {
            GameController.Instance.Check4 = true;
            DiminuirEscala.instancia.ReiniciarV();
        }

        if (other.gameObject.tag == "SafeCheck")
        {
            GameController.Instance.SafeCheck1 = true;
            if (GameController.Instance.Check1)
            {
                DiminuirEscala.instancia.ReiniciarV();
            }
            
        }
        if (other.gameObject.tag == "SafeCheck1")
        {
            GameController.Instance.SafeCheck2 = true;
            if (GameController.Instance.Check2)
            {
                DiminuirEscala.instancia.ReiniciarV();
            }
            
        }
        if (other.gameObject.tag == "SafeCheck2")
        {
            GameController.Instance.SafeCheck3 = true;
            if (GameController.Instance.Check3)
            {
                DiminuirEscala.instancia.ReiniciarV();
            }
            
        }
        if (other.gameObject.tag == "SafeCheck3")
        {
            Debug.Log("AA");
            GameController.Instance.SafeCheck4 = true;
            if (GameController.Instance.Check4)
            {
                DiminuirEscala.instancia.ReiniciarV();
            }
            
        }
    }
    private void OnTriggerStay(Collider other)
    {
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "SafeCheck")
        {
            GameController.Instance.SafeCheck1= false;
            DiminuirEscala.instancia.Diminuir();

        }
        if (other.gameObject.tag == "SafeCheck1")
        {
            GameController.Instance.SafeCheck2= false;
            DiminuirEscala.instancia.Diminuir();

        }
        if (other.gameObject.tag == "SafeCheck2")
        {
            GameController.Instance.SafeCheck3= false;
            DiminuirEscala.instancia.Diminuir();

        }
        if (other.gameObject.tag == "SafeCheck3")
        {
            GameController.Instance.SafeCheck4= false;
            DiminuirEscala.instancia.Diminuir();

        }
    }
    
}
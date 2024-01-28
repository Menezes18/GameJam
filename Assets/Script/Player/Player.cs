using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float horizontal;
    private float speed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;
    public float pushForce = 5f;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public Animator clip;

    public GameObject[] sumir;
    public float count = 0;
    public bool enter;
    public bool desativado = true;
    public bool Caindo = true;
    void Update()
    {
        if (Caindo)
        {
        horizontal = Input.GetAxisRaw("Horizontal");
        
        }

        if (Input.GetKeyDown(KeyCode.Space)  && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            clip.SetTrigger("Jump");
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
            
            clip.SetBool("Run", true);
        }
        else
        {
            clip.SetBool("Run", false);
        }

        if (enter)
        {
            Enter();
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
        if (other.gameObject.tag == "Caixa")
        {
            clip.SetBool("Pushing", true);
        }
        if (other.gameObject.tag == "Cair")
        {
            Caindo = false;
            clip.SetBool("Cair",true);
        }
        if (other.gameObject.tag == "Caindodochao")
        {
            Caindo = false;
            clip.SetBool("Cair",false);
            horizontal = 0f;
            Invoke("VoltandoAoNormal", 5f);
        }
        if (other.gameObject.tag == "CheckPoint")
        {
            LightManager.Instance.MudarCorLuz(Color.red, 0);
            DiminuirEscala.instancia.IniicoShader = false;
            GameController.Instance.Check1 = true;
            DiminuirEscala.instancia.ReiniciarV();
        }
        if (other.gameObject.tag == "CheckPoint1")
        {
            LightManager.Instance.MudarCorLuz(Color.red, 1);
            GameController.Instance.Check2 = true;
            DiminuirEscala.instancia.ReiniciarV();
        }
        if (other.gameObject.tag == "CheckPoint2")
        {
            LightManager.Instance.MudarCorLuz(Color.red, 2);
            GameController.Instance.Check3 = true;
            DiminuirEscala.instancia.ReiniciarV();
        }
        if (other.gameObject.tag == "CheckPoint3")
        {
            LightManager.Instance.MudarCorLuz(Color.red, 3);
            GameController.Instance.Check4 = true;
            DiminuirEscala.instancia.ReiniciarV();
            sumir[0].SetActive(false);
            sumir[1].SetActive(false);
            sumir[2].SetActive(false);
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
            Debug.Log("B");
            enter = true;
            if (desativado)
            {
                Debug.Log("Dentro do desativado");
                GameController.Instance.SafeCheck4 = true;
                if (GameController.Instance.Check4)
                {
                    DiminuirEscala.instancia.ReiniciarV();
                }
                enter = true;
            }


        }
    }

    public void VoltandoAoNormal()
    {
        Caindo = true;
    }

    public void Enter()
    {
        count += Time.deltaTime;
        if (count >= 5)
        {
            
            LightManager.Instance.luz[3].intensity = 0.1f;
            LightManager.Instance.luz[4].gameObject.SetActive(true);
            desativado = false;
            GameController.Instance.SafeCheck4= false;
            DiminuirEscala.instancia.Diminuir();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "SafeCheck")
        {
            LightManager.Instance.MudarCorLuz(Color.white, 0);
            GameController.Instance.SafeCheck1= false;
            DiminuirEscala.instancia.Diminuir();

        }
        if (other.gameObject.tag == "SafeCheck1")
        {
            LightManager.Instance.MudarCorLuz(Color.white, 1);
            GameController.Instance.SafeCheck2= false;
            DiminuirEscala.instancia.Diminuir();

        }
        if (other.gameObject.tag == "SafeCheck2")
        {
            LightManager.Instance.MudarCorLuz(Color.white, 2);
            GameController.Instance.SafeCheck3= false;
            DiminuirEscala.instancia.Diminuir();

        }
        if (other.gameObject.tag == "SafeCheck3")
        {
            LightManager.Instance.MudarCorLuz(Color.white, 3);
            GameController.Instance.SafeCheck4= false;
            DiminuirEscala.instancia.Diminuir();

        }
        if (other.gameObject.tag == "Caixa")
        {
            clip.SetBool("Pushing", false);
        }
    }
    
}
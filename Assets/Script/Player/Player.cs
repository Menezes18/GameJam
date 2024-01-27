using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade = 5f;  // Velocidade de movimentação do personagem
    public float forcaPulo = 10f;  // Força do pulo
    public bool estaNoChao;
    public DiminuirEscala configEscala;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

                
        if (Input.GetKeyDown(KeyCode.E))
        {
            configEscala.CongelarEscala();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            configEscala.IniciarReiniciarEscala();
        }
        // Movimentação horizontal
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        Vector2 movimento = new Vector2(movimentoHorizontal, 0);
        transform.Translate(movimento * velocidade * Time.deltaTime);

        // Pulo
        if (Input.GetKeyDown(KeyCode.W) && estaNoChao)
        {
            rb.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
            estaNoChao = false;
        }
        
    }


    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Chao")
        {
            estaNoChao = true;
        }
    }
}

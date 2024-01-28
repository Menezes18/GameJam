using System;
using UnityEngine;

public class DiminuirEscala : MonoBehaviour
{
    public static DiminuirEscala instancia;
    public Vector3 escalaInicial = new Vector3(2.983649f, 1.904173f, 2.983649f);
    public Vector3 inicioShader = new Vector3(11.82644f, 7.547668f, 11.82644f);
    public Vector3 escalaFinal = new Vector3(0.003f, 0.002f, 0.003f); // Ajuste essa escala conforme necessário
    public Vector3 Atual;
    private float tempoParaDiminuir = 25f; // Tempo (em segundos)
    private float tempoPassado;
    public bool diminuir = false;
    public bool reiniciar = false;
    public bool IniicoShader = false;

    public void Awake()
    {
        instancia = this;
        tempoPassado = 0f;
        diminuir = false;
        reiniciar = false;
       // escalaInicial = transform.localScale;
        
    }

    public void ativarShader()
    {
        IniicoShader = true;
    }
    public void Start()
    {
        transform.localScale = new Vector3(10.14f, 6.4f, 10.14f);
        IniicoShader = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) )
        {
            Diminuir();
        }

        if (Input.GetKeyDown(KeyCode.R) )
        {
            ReiniciarV();
        }

        if (diminuir)
        {
            DiminuirObjetoGradualmente();
        }

        if (reiniciar)
        {
            AumentarObjetoGradualmente();
        }

        if (IniicoShader)
        {
            DiminuirObjetoGradualmenteInicio();
        }
    }

    public void InicioDiminuir()
    {
        diminuir = true;
        reiniciar = false;
        tempoPassado = 0f;
    }
    public void Diminuir()
    {
        diminuir = true;
        reiniciar = false;
        tempoPassado = 0f;
    }

    public void ReiniciarV()
    {
        diminuir = false;
        reiniciar = true;
        tempoPassado = 0f;
    }

    public void final()
    {
        transform.localScale = new Vector3(10f, 6f, 10f);
    }
    void DiminuirObjetoGradualmenteInicio()
    {
        tempoPassado += Time.deltaTime;

        // Interpola linearmente entre a escala inicial e final ao longo do tempo
        transform.localScale = Vector3.Lerp(inicioShader, escalaFinal, tempoPassado / tempoParaDiminuir);

        // Garante que a escala final seja exatamente a desejada
        if (tempoPassado >= tempoParaDiminuir)
        {
            transform.localScale = escalaFinal;

            // Reinicia o tempo passado para futuras chamadas
            tempoPassado = 0f;
            IniicoShader = false;
            if (transform.localScale == escalaFinal)
            {
                GameController.Instance.Reiniciar();
            }
        }
    }
    void DiminuirObjetoGradualmente()
    {
        tempoPassado += Time.deltaTime;

        // Interpola linearmente entre a escala inicial e final ao longo do tempo
        transform.localScale = Vector3.Lerp(escalaInicial, escalaFinal, tempoPassado / tempoParaDiminuir);

        // Garante que a escala final seja exatamente a desejada
        if (tempoPassado >= tempoParaDiminuir)
        {
            transform.localScale = escalaFinal;

            // Reinicia o tempo passado para futuras chamadas
            tempoPassado = 0f;
            diminuir = false;
            if (transform.localScale == escalaFinal)
            {
                GameController.Instance.Reiniciar();
            }
        }
    }

    public void AumentarObjetoGradualmente()
    {
        tempoPassado += Time.deltaTime;
        Atual = transform.localScale;
        // Interpola linearmente entre a escala atual e a escala original ao longo do tempo
        transform.localScale = Vector3.Lerp(Atual, escalaInicial, tempoPassado / tempoParaDiminuir);

        // Garante que a escala final seja exatamente a desejada
        if (tempoPassado >= tempoParaDiminuir)
        {
            transform.localScale = escalaInicial;

            // Reinicia o tempo passado para futuras chamadas
            tempoPassado = 0f;
            reiniciar = false;
        }
    }
}

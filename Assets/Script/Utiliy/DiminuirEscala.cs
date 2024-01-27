using UnityEngine;

public class DiminuirEscala : MonoBehaviour
{
    public Vector3 escalaFinal = new Vector3(0.003f, 0.002f, 0.003f); // Ajuste essa escala conforme necessário
    public float tempoParaDiminuir = 10f; // Tempo (em segundos) para atingir a escala final
    private float tempoPassado = 0f;
    private bool diminuir = false;
    private bool reiniciar = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) // Você pode alterar a tecla conforme necessário
        {
            diminuir = true;
            reiniciar = false;
            tempoPassado = 0f;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (diminuir)
            {
                diminuir = false;
                reiniciar = true;
                tempoPassado = 0f;
            }
            else
            {
                reiniciar = false;
                AumentarObjetoGradualmente();
            }
        }

        if (diminuir)
        {
            DiminuirObjetoGradualmente();
        }

        if (reiniciar)
        {
            AumentarObjetoGradualmente();
        }
        
    }

    void FixedUpdate()
    {
        // Se você não estiver usando FixedUpdate para nada específico, remova esta função
    }

    void DiminuirObjetoGradualmente()
    {
        Vector3 escalaInicial = transform.localScale;

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
        }
    }

    public void AumentarObjetoGradualmente()
    {
        Vector3 escalaAtual = transform.localScale;
        

        if (tempoPassado < tempoParaDiminuir)
        {
            tempoPassado += Time.deltaTime;

            // Interpola linearmente entre a escala atual e a escala original ao longo do tempo
            var PrimeiraEscala = new Vector3(2.983649f, 1.904173f, 2.983649f);
            transform.localScale = Vector3.Lerp(escalaAtual, PrimeiraEscala, tempoPassado / tempoParaDiminuir);
        }
        else
        {
            // Garante que a escala final seja exatamente a desejada
            transform.localScale = new Vector3(2.983649f, 1.904173f, 2.983649f);

            // Reinicia o tempo passado para futuras chamadas
            tempoPassado = 0f;
            reiniciar = false;
        }
    }
}

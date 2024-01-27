using UnityEngine;

public class DiminuirEscala : MonoBehaviour
{
    
    public Vector3 escalaFinal = new Vector3(112f, 0f, 60f); // A escala final desejada
    public Vector3 escala;
    public float duracaoDaAnimacao = 2.0f; 
    public float duracaoDoReinicio = 1.0f; // Duração da animação de reinício

    private Vector3 escalaInicial; 
    private float tempoDecorrido = 0f; 
    private bool congelarEscala = false; 
    private bool reiniciando = false; 

    void Start()
    {
        escalaInicial = transform.localScale; 
    }

    void FixedUpdate()
    {
        escala = transform.localScale;
        if (reiniciando)
        {
            tempoDecorrido += Time.deltaTime;

            float t = tempoDecorrido / duracaoDoReinicio;
            transform.localScale = Vector3.Lerp(escala, escalaInicial, t);

            if (tempoDecorrido >= duracaoDoReinicio)
            {
                reiniciando = false;
                tempoDecorrido = 0f;
                Debug.Log("Reinicialização concluída!");
            }
        }
        else if (!congelarEscala)
        {
            tempoDecorrido += Time.deltaTime;

            float t = tempoDecorrido / duracaoDaAnimacao;
            transform.localScale = Vector3.Lerp(escalaInicial, escalaFinal, t);

            if (tempoDecorrido >= duracaoDaAnimacao)
            {
                Debug.Log("Animação concluída!");
                tempoDecorrido = 0f; // Reinicia o tempoDecorrido para permitir reiniciar a animação.
            }
        }

    }

    // Método para iniciar o reinício da escala
    public void IniciarReiniciarEscala()
    {
        reiniciando = true;
        tempoDecorrido = 0f;
        Debug.Log("Iniciando reinicialização...");
    }

    // Método para reiniciar a escala
    public void ReiniciarEscala()
    {
        IniciarReiniciarEscala();
    }

    // Método para congelar/descongelar a escala
    public void CongelarEscala()
    {
        congelarEscala = !congelarEscala; // Inverte o estado do congelamento
    }
}

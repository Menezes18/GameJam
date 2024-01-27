using UnityEngine;
using UnityEngine.SceneManagement;
public class Damage : MonoBehaviour
{
    
    public string tagDeDano = "Player";

    
    private Vector3 posicaoInicial;

    void Start()
    {
        
        posicaoInicial = transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.tag == tagDeDano)
        {
            
            Destroy(collision.gameObject);

            
            Invoke("ReiniciarPosicao", 1.0f);
        }
    }

    void ReiniciarPosicao()
    {
        
        string cenaAtual = SceneManager.GetActiveScene().name;

        
        SceneManager.LoadScene(cenaAtual);

    }
}
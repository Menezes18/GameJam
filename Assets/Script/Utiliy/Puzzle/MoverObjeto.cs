using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverObjeto : MonoBehaviour
{
    private Transform objetoSelecionado;
    private Vector3 posiçãoInicial;
    public List<GameObject> cubos = new List<GameObject>();
    public List<GameObject> tentativa = new List<GameObject>();
    public GameObject ObjetoClick;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Objeto"))
            {
                ObjetoClick = hit.collider.gameObject;
                if (!tentativa.Contains(ObjetoClick))
                {
                    tentativa.Add(ObjetoClick);
                   
                }

                Verifica();
                // if (Cubos[tentativa.Count].name == hit.collider.gameObject.name)
                // {
                //     tentativa.Add(hit.collider.gameObject);
                //     if (tentativa.Count == Cubos.Length)
                //     {
                //         //concluiu
                //     }
                //     Debug.Log(tentativa);
                // } else {
                //     tentativa.Clear();
                //     //funcao voltar blocos para posiccao inicial
                // }
                if (objetoSelecionado == null)
                {
                    // Se nenhum objeto foi selecionado, guarda o objeto e sua posição
                    Debug.Log(hit.collider.gameObject.name);
                    objetoSelecionado = hit.transform;
                    posiçãoInicial = objetoSelecionado.position;
                }
                else
                {
                    // Se já há um objeto selecionado, troca suas posições
                    TrocarPosicoes(objetoSelecionado, hit.transform);
                    objetoSelecionado = null;
                }
            }
        }
    }

    public void Verifica()
    {
       
        if (tentativa.Count == cubos.Count)
        {
            bool sequenciaCorreta = true;

            
            for (int i = 0; i < tentativa.Count; i++)
            {
                if (cubos[i].gameObject.name != tentativa[i].gameObject.name)
                {
                    sequenciaCorreta = false;
                    break; 
                }
            }

            
            if (sequenciaCorreta)
            {
                Debug.Log("Sequência Correta! Acertou");
            }
            else
            {
                Debug.Log("Sequência Incorreta! Tente novamente");
                
                
                tentativa.Clear();
            }
        }
    }

    void TrocarPosicoes(Transform objeto1, Transform objeto2)
    {
        Vector3 posicaoObjeto1 = objeto1.position;
        Vector3 posicaoObjeto2 = objeto2.position;
        StartCoroutine(AnimePosicao(objeto1, posicaoObjeto2));
        StartCoroutine(AnimePosicao(objeto2, posicaoObjeto1));
        
    }

    IEnumerator AnimePosicao(Transform objeto, Vector3 posicao)
    {
        yield return new WaitForFixedUpdate();
        objeto.position = Vector3.Lerp(objeto.position,posicao,.05f);

        if (Vector3.Distance(objeto.position, posicao) > .1f){
            StartCoroutine(AnimePosicao(objeto, posicao));
        }
    }

}
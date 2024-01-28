using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorLinha : MonoBehaviour
{
    public GameObject linha_prefab;
    public GameObject[] objetos;
    private GameObject[] linha;

    private GameManagerBlock GameController = null;
    
    void Awake()
    {
        if(GameObject.Find("GameController") != null)
            GameController = GameObject.Find("GameController").GetComponent<GameManagerBlock>();
    }

    void Start()
    {
        linha = new GameObject[objetos.Length];

        for(int i = 0; i < objetos.Length; i++){
            linha[i] = Instantiate(linha_prefab, transform.position, transform.rotation);
        }
        if(GameController != null)
            GameController.QuantidadeColisoes -= objetos.Length;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < objetos.Length; i++){
            Vector3 proximo;
            if(i == 0){
                proximo = transform.position;
            }else{
                proximo = objetos[i-1].transform.position;
            }
            Vector3 between = objetos[i].transform.position - proximo;
            float distance = between.magnitude;     
            
            linha[i].transform.localScale = new Vector3(1, 1, distance); 
            linha[i].transform.position = proximo + (between / 2f);        
            linha[i].transform.LookAt(objetos[i].transform.position);
        }        
    }
}

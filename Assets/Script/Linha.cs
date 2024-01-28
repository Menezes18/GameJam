using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;

public class Linha : MonoBehaviour
{

    private GameManagerBlock GameController = null;
    // Start is called before the first frame update
    void Awake()
    {
        if(GameObject.Find("GameController") != null)
            GameController = GameObject.Find("GameController").GetComponent<GameManagerBlock>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        
        if(other.CompareTag("Linha")){        

            if(GameController != null){
                GameController.QuantidadeColisoes++;
                
            }

        }

    }

    private void OnTriggerExit(Collider other) {
        
        if(other.CompareTag("Linha")){

            if(GameController != null){
                GameController.QuantidadeColisoes--;
                
            }

        }

    }    
}

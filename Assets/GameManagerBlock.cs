using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManagerBlock: MonoBehaviour
{
    private GameObject objeto1 = null, objeto2 = null;
    private Vector3 pos_objeto1, pos_objeto2;
    private Ray ray;
    private RaycastHit hit;

   // public TextMeshProUGUI HUD_Text;

    public int QuantidadeColisoes = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            if(Input.GetMouseButtonDown(0)){
                if(hit.collider.CompareTag("Objeto")){                    

                    if(objeto1 == null || objeto2 == null){                        

                        if(objeto1 == null){
                            objeto1 = hit.collider.gameObject;
                        }else{
                            objeto2 = hit.collider.gameObject;
                        }

                        if(objeto1 != null && objeto2 != null){
                            pos_objeto1 = objeto2.transform.position;
                            pos_objeto2 = objeto1.transform.position;

                            StartCoroutine(trocarPosicoes());
                        }
                    }
                }
            }
        }        
    }

    IEnumerator trocarPosicoes(){

        yield return new WaitForFixedUpdate();

        objeto1.transform.position = Vector3.Lerp(objeto1.transform.position, pos_objeto1, .05f);
        objeto2.transform.position = Vector3.Lerp(objeto2.transform.position, pos_objeto2, .05f);

        if(Vector3.Distance(objeto1.transform.position, pos_objeto1) > .2f){
            StartCoroutine(trocarPosicoes());
        }else{
            objeto1 = null;
            objeto2 = null;
        }

    }

    // public void AtualizarHUD(){
    //
    //     HUD_Text.text = "Quantidade Colisões: "+(QuantidadeColisoes/2);
    //
    // }
   
}



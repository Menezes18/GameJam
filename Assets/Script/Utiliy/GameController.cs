using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool Check1, Check2, Check3, Check4;
    
    public bool SafeCheck1, SafeCheck2, SafeCheck3, SafeCheck4;
    private static GameController instance;

    public void Awake()
    {
        
    }

    public static GameController Instance
    {
        get
        {
            
            if (instance == null)
            {
                instance = FindObjectOfType<GameController>();

                
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("GameController");
                    instance = singletonObject.AddComponent<GameController>();
                }
            }
            return instance;
        }
    }

    public void ReiniciarShader()
    {
        DiminuirEscala.instancia.reiniciar = true;
    }
    public void Reiniciar()
    {
        
        string cenaAtual = SceneManager.GetActiveScene().name;

        
        SceneManager.LoadScene(cenaAtual);

    }
    
    


}
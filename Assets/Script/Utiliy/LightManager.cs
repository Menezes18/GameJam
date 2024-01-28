using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    // Referência para o componente de luz
    public Light[] luz;
    private static LightManager instance;
    public static LightManager Instance
    {
        get
        {
            
            if (instance == null)
            {
                instance = FindObjectOfType<LightManager>();
            }
            return instance;
        }
    }

    public void Awake()
    {
        instance = this;
    }

    // Função para mudar a cor da luz
    public void MudarCorLuz(Color novaCor, int numero)
    {
        // Verificar se o componente de luz foi encontrado
        if (luz != null)
        {
            luz[numero].color = novaCor;
        }
        else
        {
            
            Debug.LogError("Componente de luz não encontrado.");
        }
    }
}


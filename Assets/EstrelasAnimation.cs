using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstrelasAnimation : MonoBehaviour
{
    public Animator estrelaInicio;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            estrelaInicio.SetTrigger("Inicio");
        }
    }
    
}

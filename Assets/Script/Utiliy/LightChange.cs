using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChange : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "CheckPoint")
        {
            LightManager.Instance.MudarCorLuz(Color.red, 0);
            
        }

        if (other.gameObject.tag == "CheckPoint1")
        {
            LightManager.Instance.MudarCorLuz(Color.red, 1);
            
        }

        if (other.gameObject.tag == "CheckPoint2")
        {
            LightManager.Instance.MudarCorLuz(Color.red, 2);
            
        }

        if (other.gameObject.tag == "CheckPoint3")
        {
            LightManager.Instance.MudarCorLuz(Color.red, 3);
           
        }
    }
}

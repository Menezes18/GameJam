using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class TriggerCamera : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public DiminuirEscala di;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            di.final();
            di.IniicoShader = true;
            virtualCamera.m_Lens.OrthographicSize = 30f;
        }
    }
}

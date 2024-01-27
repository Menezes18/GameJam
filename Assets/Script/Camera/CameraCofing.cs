using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;    

/// <summary>
/// An add-on module for Cinemachine Virtual Camera that locks the camera's X co-ordinate
/// </summary>
[ExecuteInEditMode]
[SaveDuringPlay]
[AddComponentMenu("")] // Hide in menu
public class CameraConfig : CinemachineExtension
{
    [Tooltip("Lock the camera's Y position to this value")]
    public float m_XPosition = 0;
 
    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Finalize)
        {
            var pos = state.RawPosition;
            pos.y = m_XPosition;
            state.RawPosition = pos;
        }
    }
}



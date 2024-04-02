using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    CinemachineVirtualCamera virtualCamera;
    CinemachineFramingTransposer transposer;
    private void Start() {
        virtualCamera=GetComponent<CinemachineVirtualCamera>();
        transposer= (CinemachineFramingTransposer)virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
    }
    
    void Update()
    {
        if (Input.mouseScrollDelta.y<0&&transposer.m_CameraDistance<13)
        {
            transposer.m_CameraDistance+=0.5f;
        }
        if (Input.mouseScrollDelta.y>0&&transposer.m_CameraDistance>9)
        {
            transposer.m_CameraDistance-=0.5f;
        }
    }
}

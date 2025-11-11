using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

//挂载在Virtual Camera身上的脚本
//作用：实现摄像机的镜头抖动
public class CameraControl : MonoBehaviour
{
    [Header("事件监听")]
    public VoidEventSO cameraImpulse;

    public CinemachineImpulseSource impulseSource;

    void OnEnable()
    {
        cameraImpulse.OnEventRaised += OnCameraShakeEvent;
    }

    void OnDisable()
    {
        cameraImpulse.OnEventRaised -= OnCameraShakeEvent;
    }

    private void OnCameraShakeEvent()
    {
        impulseSource.GenerateImpulse();
    }

}

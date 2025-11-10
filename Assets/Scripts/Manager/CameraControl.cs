using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

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

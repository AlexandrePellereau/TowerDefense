using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;


public class CameraShake : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    public float shakeIntensity = 1;
    public float shakeTime = 0.2f;
    
    private float _timer;
    private CinemachineBasicMultiChannelPerlin _cinemachineBasicMultiChannelPerlin;
    
    public static CameraShake Instance;

    private void Start()
    {
        _cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        StopShake();
        Instance = this;
    }

    public void ShakeCamera()
    {
        _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = shakeIntensity;
        //_timer = shakeTime;
        Invoke(nameof(StopShake), shakeTime);
    }
    
    public void StopShake()
    {
        _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;
        //_timer = 0;
    }
}

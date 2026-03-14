using Cinemachine;
using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraManager
{
    private List<CinemachineVirtualCamera> _cameras = new List<CinemachineVirtualCamera>();

    private CinemachineBrain _brain;
    public CinemachineBrain Brain => _brain;
    public CameraManager(CinemachineBrain brain) => _brain = brain;
    public void RegisterCamera(CinemachineVirtualCamera camera) => _cameras.Add(camera);
    public void SetCameraPriority(PlayerBase player)
    {
        foreach (var camera in _cameras)
            camera.Priority = player._playerCamera == camera ? GameConstant.CameraPriority.ACTIVE_PRIORITY : GameConstant.CameraPriority.DEACTIVE_PRIORITY;
    }
}

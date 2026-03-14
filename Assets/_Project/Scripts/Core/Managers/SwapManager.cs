using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Cysharp.Threading.Tasks;
using System;

public class SwapManager : MonoBehaviour
{
    private const float _standUpDuration = 6.1f;

    private CameraManager _cameraManager;

    [Inject]
    public void Construct(CameraManager cameraManager) => _cameraManager = cameraManager;

    [Header("Player References")]
    [SerializeField] private List<PlayerBase> _players = new List<PlayerBase>();

    private PlayerBase _activePlayer;
    private void Start() => Initialize();
    private void Initialize()
    {
        _activePlayer = _players[0];

        foreach (var player in _players)
        {
            if (player != _activePlayer)
                player.DeactivatePlayer();
        }

        _activePlayer.ActivatePlayer();
        _cameraManager.SetCameraPriority(_activePlayer);
    }
    public void SwapPlayer(GameSignal.OnPlayerSwapSignal signal)
    {
        if (_activePlayer.Data.Identity == signal.NewPlayerIdentity)
            return;

        SwapPlayerSequence(signal).Forget();
    }
    private async UniTask SwapPlayerSequence(GameSignal.OnPlayerSwapSignal signal)
    {
        if(CanSwap())
        {
            foreach (var player in _players)
                player.DeactivatePlayer();

            _activePlayer = null;
            _activePlayer = _players.Find(player => player.Data.Identity == signal.NewPlayerIdentity);

            _cameraManager.SetCameraPriority(_activePlayer);

            await UniTask.Yield();

            await UniTask.WaitUntil(() => !_cameraManager.Brain.IsBlending);

            _activePlayer.AnimationController.PlayAnimation(GameConstant.PlayerAnimation.STAND_UP_HASH, GameConstant.AnimationSettings.SMOOTH_TRANSITION);

            await UniTask.Delay(TimeSpan.FromSeconds(_standUpDuration));

            _activePlayer.ActivatePlayer();
        }
        else
        {
            //TODO Uyarý yazýsý eklenecek.
            Debug.Log("Player only can Swap on grounded");
        }
    }
    public bool CanSwap() => _activePlayer.IsGrounded();
}

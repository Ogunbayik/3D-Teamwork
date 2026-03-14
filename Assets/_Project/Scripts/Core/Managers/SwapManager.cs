using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapManager : MonoBehaviour
{
    [Header("Player References")]
    [SerializeField] private List<PlayerBase> _players = new List<PlayerBase>();

    private PlayerBase _activePlayer;
    private void Start() => Initialize();
    private void Initialize()
    {
        _activePlayer = _players[0];
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T) && CanSwap())
        {
            foreach (var player in _players)
            {
                player.StateMachine.SwitchState<PlayerPassiveState>();
                player.enabled = false;
            }

            _activePlayer = _players[0];
            _activePlayer.enabled = true;
            _activePlayer.StateMachine.SwitchState<PlayerIdleState>();
        }
    }
    public void AddPlayer(PlayerBase player) => _players.Add(player);
    public bool CanSwap() => _activePlayer.IsGrounded();
}

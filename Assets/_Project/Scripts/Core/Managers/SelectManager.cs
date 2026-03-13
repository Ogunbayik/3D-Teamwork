using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    [Header("Player References")]
    [SerializeField] private List<PlayerBase> _players = new List<PlayerBase>();

    private PlayerBase _activePlayer;
    private void Start() => Initialize();
    private void Initialize()
    {

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            foreach (var player in _players)
                player.StateMachine.SwitchState<PlayerPassiveState>();

            _activePlayer = _players[0];
            _activePlayer.StateMachine.SwitchState<PlayerIdleState>();
        }
    }
    public void AddPlayer(PlayerBase player) => _players.Add(player);
}

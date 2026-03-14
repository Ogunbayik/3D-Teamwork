using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SwapButton : MonoBehaviour
{
    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus) => _signalBus = signalBus;

    [Header("UI References")]
    [SerializeField] private PlayerIdentity _identity;
    [SerializeField] private Button _swapButton;
    void Start() => _swapButton.onClick.AddListener(() => RequestSwapSignal());
    private void RequestSwapSignal() => _signalBus.Fire(new GameSignal.OnPlayerSwapSignal(_identity));
}

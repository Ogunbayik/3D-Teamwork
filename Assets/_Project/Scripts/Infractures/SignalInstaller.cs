using UnityEngine;
using Zenject;

public class SignalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<GameSignal.OnPlayerSwapSignal>();

        Container.BindSignal<GameSignal.OnPlayerSwapSignal>()
            .ToMethod<SwapManager>(x => x.SwapPlayer)
            .FromResolve();
    }
}
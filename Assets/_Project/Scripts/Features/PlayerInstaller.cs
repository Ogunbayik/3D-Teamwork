using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerBase>().FromComponentOnRoot().AsSingle();
        Container.Bind<CharacterController>().FromComponentOnRoot().AsSingle();

        Container.Bind<IState>().To<PlayerIdleState>().AsSingle();
        Container.Bind<IState>().To<PlayerMoveState>().AsSingle();
        Container.Bind<IState>().To<PlayerAirborneState>().AsSingle();

        Container.BindInterfacesAndSelfTo<PlayerStateMachine>().AsSingle().NonLazy();
    }
}
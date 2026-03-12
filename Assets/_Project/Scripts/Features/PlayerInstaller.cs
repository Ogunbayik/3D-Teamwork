using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        //------------------GENERAL---------------
        Container.Bind<PlayerBase>().FromComponentOnRoot().AsSingle();
        Container.Bind<CharacterController>().FromComponentOnRoot().AsSingle();

        Container.Bind<Animator>().FromComponentInHierarchy().AsSingle();
        Container.Bind<AnimationController>().AsSingle();

        //------------------STATES----------------
        Container.Bind<IState>().To<PlayerIdleState>().AsSingle();
        Container.Bind<IState>().To<PlayerMoveState>().AsSingle();
        Container.Bind<IState>().To<PlayerAirborneState>().AsSingle();

        Container.BindInterfacesAndSelfTo<PlayerStateMachine>().AsSingle().NonLazy();


    }
}
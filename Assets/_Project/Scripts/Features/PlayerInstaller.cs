using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        //------------------GENERAL---------------
        Container.Bind<PlayerBase>().FromComponentOnRoot().AsSingle();

        Container.Bind<CharacterController>().FromComponentOnRoot().AsSingle();
        Container.Bind<SkinnedMeshRenderer>().FromComponentInHierarchy().AsSingle();

        Container.Bind<Animator>().FromComponentInHierarchy().AsSingle();
        Container.Bind<AnimationController>().AsSingle();

        //------------------STATES----------------
        Container.Bind<IState>().To<PlayerIdleState>().AsSingle();
        Container.Bind<IState>().To<PlayerWalkState>().AsSingle();
        Container.Bind<IState>().To<PlayerSprintState>().AsSingle();
        Container.Bind<IState>().To<PlayerPassiveState>().AsSingle();
        Container.Bind<IState>().To<PlayerJumpState>().AsSingle();
        Container.Bind<IState>().To<PlayerFallState>().AsSingle();

        Container.BindInterfacesAndSelfTo<PlayerStateMachine>().AsSingle().NonLazy();


    }
}
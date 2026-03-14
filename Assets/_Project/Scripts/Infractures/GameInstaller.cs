using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [Header("Manager References")]
    [SerializeField] private SwapManager _swapManager;

    public override void InstallBindings()
    {
        Container.Bind<IInputService>().To<InputService>().AsSingle();

        Container.BindInstance(_swapManager);
    }
}
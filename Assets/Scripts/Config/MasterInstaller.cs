using UnityEngine;
using Zenject;

public class MasterInstaller : MonoInstaller
{
    [NotNull]
    [SerializeField]
    private ThreadedCoroutine singleton_ThreadedCoroutine;
    [NotNull]
    [SerializeField]
    private GameStateManager singleton_GameStateManager;

    public override void InstallBindings()
    {
        // Singletons
        Container.Bind<ThreadedCoroutine>().FromInstance(singleton_ThreadedCoroutine);
        Container.Bind<GameStateManager>().FromInstance(singleton_GameStateManager);

        // Self References
        Container.Bind<Rigidbody2D>().FromComponentSibling();
        Container.Bind<Camera>().FromComponentSibling();
    }
}

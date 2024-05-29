using Data;
using Infrastructure;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();
        Container.BindInterfacesAndSelfTo<DataSaver>().AsSingle();
        Container.BindInterfacesAndSelfTo<Factory>().AsSingle();
        Container.BindInterfacesAndSelfTo<EnemyFactory>().AsSingle();
    }
}
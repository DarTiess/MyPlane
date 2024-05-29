using Infrastructure.EventsBus;
using Input;
using UnityEngine;
using Zenject;

public class GlobalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        CreateInputService();
        CreateEventBus();
    }

    private void CreateEventBus()
    {
        Container.BindInterfacesAndSelfTo<EventBus>().AsSingle();
    }

    private void CreateInputService()
    {
        if (Application.isEditor)
        {
            Container.BindInterfacesAndSelfTo<StandaloneInputService>().AsSingle();
        }
        else
        {
            Container.BindInterfacesAndSelfTo<MobileInputService>().AsSingle();
        }
    }
}

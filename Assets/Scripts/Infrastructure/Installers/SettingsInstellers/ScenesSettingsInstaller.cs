using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ScenesSettingsInstaller", menuName = "Installers/ScenesSettingsInstaller")]
public class ScenesSettingsInstaller : ScriptableObjectInstaller<ScenesSettingsInstaller>
{
    public ScenesSettings ScenesSettings;
    public override void InstallBindings()
    {
        Container.BindInstance(ScenesSettings);
    }
}
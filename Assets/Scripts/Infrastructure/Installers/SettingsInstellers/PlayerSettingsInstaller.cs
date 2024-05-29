using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "PlayerSettingsInstaller", menuName = "Installers/PlayerSettingsInstaller")]
public class PlayerSettingsInstaller : ScriptableObjectInstaller<PlayerSettingsInstaller>
{
    public PlayerSettings PlayerSettings;
    public override void InstallBindings()
    {
        Container.BindInstance(PlayerSettings);
    }
}
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "EnemiesSettingsInstaller", menuName = "Installers/EnemiesSettingsInstaller")]
public class EnemiesSettingsInstaller : ScriptableObjectInstaller<EnemiesSettingsInstaller>
{
    public EnemySettings EnemySettings;
    public override void InstallBindings()
    {
        Container.BindInstance(EnemySettings);
    }
}
using Enemy;
using Infrastructure.Level.EventsBus;
using UnityEngine;

public class EnemyFactory
{
    private ObjectPoole<EnemyView> _enemyPoole;
    private readonly EnemySettings _settings;
    private readonly IEventBus _eventBus;
    
    public EnemyFactory(IEventBus eventBus, EnemySettings settings)
    {
        _settings = settings;
        _eventBus = eventBus;
    }

    public void CreateEnemies( Transform player)
    {
        for (int i = 0; i < _settings.View.Count; i++)
        {
            _enemyPoole = new ObjectPoole<EnemyView>();
            _enemyPoole.CreatePool(_settings.Prefab,1, null);
            EnemyView enemy = _enemyPoole.GetObject();
            enemy.transform.position = GetEnemyRandomPosition(player, _settings.View.Count);
            enemy.Init(_eventBus,player, _settings.View[i]);
        }
    }
    private Vector3 GetEnemyRandomPosition(Transform player, int count)
    {
        return player.position - new Vector3(Random.Range(1,count),Random.Range(1,count));
    }
}
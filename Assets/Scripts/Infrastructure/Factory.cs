using Infrastructure.Level.EventsBus;
using Input;
using Player;
using UI;
using UnityEngine;

public class Factory
{
    private ObjectPoole<PlayerView> _playerPoole;
    private readonly IInputService _input;
    private readonly PlayerSettings _settings;
    private readonly IEventBus _eventBus;
    
    private ObjectPoole<UIControl> _uiPoole;
    private readonly UIControl _uiPrefab;

    public Factory(IInputService input,IEventBus eventBus, PlayerSettings settings)
    {
        _input = input;
        _settings = settings;
        _eventBus = eventBus;
    }

    public PlayerView CreatePlayer(Transform spawnPosition)
    {
        _playerPoole = new ObjectPoole<PlayerView>();
        _playerPoole.CreatePool(_settings.Prefab,1, null);
        PlayerView player = _playerPoole.GetObject();
        player.transform.position = spawnPosition.position;
        player.Init(_input,_eventBus,_settings);
        return player;
    }
    
    public void CreateUI(UIControl prefab)
    {
        _uiPoole = new ObjectPoole<UIControl>();
        _uiPoole.CreatePool(prefab,1, null);
        UIControl ui = _uiPoole.GetObject();
        ui.Init(_eventBus);
    }
}
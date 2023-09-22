using System;

namespace GameEvents
{
    public interface IGameEvents
    {
        event Action Gaming;
        event Action Starting;
        event Action Pause;
        event Action Fail;
    }
}
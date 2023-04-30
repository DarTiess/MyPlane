using System;

namespace GameEvents
{
    public interface IGameEvents
    {
        event Action IsGaming;
        event Action IsStarting;
        event Action OnPause;
        event Action IsFail; 
        event Action IsWin;
        void PlayGame();
    }
}
using System;

namespace Data
{
    public interface IGameOver
    {
        event  Action PlayerDied;
    }
}
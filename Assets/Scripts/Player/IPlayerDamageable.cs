using System;

namespace Player
{
    public interface IPlayerDamageable
    {
        event Action TakeDamage;
    }
}
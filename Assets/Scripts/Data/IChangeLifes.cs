using System;

namespace Data
{
    public interface IChangeLifes
    {
        event Action<int> ChangeLifes;
        int GetLifesCount();
        void ChangeLifeCount();
    }
}
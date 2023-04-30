namespace GameEvents
{
    public interface IGameState
    {
        void PlayGame();
        void FailGame();
        void TakeDamage();
        void RestartGame();
        void PauseGame();
        void QuiteGame();
    }
}
namespace GameEvents
{
    public interface IGameState
    {
        void OnPlayGame();
       
        void OnRestartGame();
        void OnPauseGame();
        void OnQuiteGame();
    }
}
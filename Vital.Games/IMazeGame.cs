namespace Vital.Games
{
    public interface IMazeGame
    {
        void StartNew(Coordinate startAt);
        bool MoveLeft();

        bool MoveRight();
        bool MoveUp();
        bool MoveDown();
        void Solve();
    }
}

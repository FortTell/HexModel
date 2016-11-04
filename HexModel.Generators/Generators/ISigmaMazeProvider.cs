namespace HexModel.Generators
{
    public interface ISigmaMazeProvider
    {
        ISigmaMaze GetMazeOfSize(MazeSize size);
    }
}

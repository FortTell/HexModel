namespace HexModel.Generators
{
    public interface IMazeGenerator
    {
        ISigmaMap<MazeCell> Construct(MapSize size);
    }
}

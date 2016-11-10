namespace HexModel.Generators
{
    public interface ITerrainGenerator
    {
        ISigmaMap<TerrainType> Construct(ISigmaMap<MazeCell> maze);
    }
}

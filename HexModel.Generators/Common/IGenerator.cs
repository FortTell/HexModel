namespace HexModel.Generators
{
    public interface IGenerator<TCell>
    {
        ISigmaMap<TCell> Construct(MapSize size);
    }
}

namespace HexModel.Generators
{
    public class MazeCell
    {
        public CellType Type { get; private set; }
        public SigmaIndex Location { get; private set; }

        public MazeCell(CellType type, SigmaIndex location)
        {
            Type = type;
            Location = location;
        }
    }
}

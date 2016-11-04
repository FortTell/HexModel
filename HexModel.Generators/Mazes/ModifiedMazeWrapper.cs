namespace HexModel.Generators
{
    class ModifiedMazeWrapper : ImmutableSigmaMaze
    {
        public ISigmaMaze ParentMaze { get; private set; }
        public SigmaIndex ModifiedLocation { get; private set; }
        public MazeCell ModifiedCell { get; private set; }

        public override MazeSize Size { get { return ParentMaze.Size; } }

        public override MazeCell this[int y, int x]
        {
            get {
                if (ModifiedLocation.Equals(new SigmaIndex(y, x)))
                    return ModifiedCell;
                else
                    return ParentMaze[y, x];
            }
        }

        public ModifiedMazeWrapper(ISigmaMaze parent, SigmaIndex modLocation, MazeCell modCell)
        {
            ParentMaze = parent;
            ModifiedLocation = modLocation;
            ModifiedCell = modCell;
        } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexModel.Generators
{
    public interface ISigmaMaze : IEnumerable<MazeCell>
    {
        MazeSize Size { get; }
        MazeCell this[SigmaIndex location] { get; }
        MazeCell this[int y, int x] { get; }
    }
}

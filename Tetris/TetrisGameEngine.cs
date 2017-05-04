using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace Tetris
{
    class TetrisGameEngine : GameEngine
    {
        public TetrisGameEngine(ConsoleGraphics graphics)
            : base(graphics)
        {
            var BigRectangle = new BigRectangle(graphics);
            AddObject(BigRectangle);
            Field Field = new Field(graphics);
            AddObject(Field);
        }
    }
}

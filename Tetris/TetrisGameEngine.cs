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
            AddObject(new BigRectangle(graphics));
            //var LFigure = new L(graphics);
            //LFigure.CreatFigure();
            //AddObject(LFigure);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace Tetris
{
    class L:GameObject
    {
        private ConsoleGraphics graphics;

        public L(ConsoleGraphics graphics)
        {
            this.graphics = graphics;
        }

        public override void Update(Field field)
        {
            throw new NotImplementedException();
        }
    }
}

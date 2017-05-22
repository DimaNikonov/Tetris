using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace Tetris
{
    abstract class IGameObject
    {
        public bool endGame { get; set; } = true;
        public int iter=0;
        public int x { get; set; } = startX;
        public int y { get; set; } = startY;
        public const int size = 25;
        public const int startX = 150;
        public const int startY = 0;       

        public abstract bool Update(Field Field, GameEngine engine);

        public virtual void Render(ConsoleGraphics graphics)
        {
        }
    }
}

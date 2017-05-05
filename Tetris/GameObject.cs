using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace Tetris
{
    abstract class GameObject
    {
        
        public abstract void Update(Field Field);

        public virtual void Render(ConsoleGraphics graphics)
        {
        }
    }
}

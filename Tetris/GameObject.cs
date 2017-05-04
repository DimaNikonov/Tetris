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
        public enum Color:uint
        {
            DEfaultColoor = 0xFFFFFFFF,
            BigRectanglColor = 0xFFD5FF30,
            LColor = 0xff306eff,
            LineColor = 0xFF80bfff,
            MirrorLColor= 0xFF003ae8,
            MirrorZColor= 0xFFb8fbff,
            TColor= 0xFF070098,
            ZColor= 0xFF269800
        };
        public abstract void Update(Field Field);

        public virtual void Render(ConsoleGraphics graphics)
        {
        }
    }
}

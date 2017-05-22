using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public struct Rectangle
    {
        public Color Color { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public byte CelsValue { get; set; }
    }
}

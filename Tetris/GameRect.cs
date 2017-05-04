using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace Tetris
{
    class GameRect : GameObject
    {
        private int i = 0;
        public int x { get; set; } = 150;
        public int y { get; set; } = 0;
        private const int size = 25;
        ConsoleGraphics graphics;

        public GameRect(ConsoleGraphics graphics)
        {
            this.graphics = graphics;
        }
        
        public override void Update(Field field)
        {
            if (y != graphics.ClientHeight - size)
            {
                if (Input.IsKeyDown(Keys.LEFT))
                {
                    if (x > 0) x -= size;
                    else x += 0;
                }
                else if (Input.IsKeyDown(Keys.RIGHT))
                {
                    if (x < graphics.ClientWidth - size - 5) x += size;
                    else x += 0;
                }
                if (Input.IsKeyDown(Keys.DOWN))
                {
                    if (y < graphics.ClientHeight - size) y += size;
                    else y += 0;
                }
                if (i % 10 == 0)
                {
                    if (y < graphics.ClientHeight - size) y += size;
                    else y += 0;
                }
                i++;
            }
        }

        public override void Render(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(0xFFFF0000, x, y, size, size);            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace Tetris
{
    class GameRect : IGameObject
    {
       
        ConsoleGraphics graphics;

        public GameRect(ConsoleGraphics graphics)
        {
            this.graphics = graphics;
        }

        public override bool Update(Field field, GameEngine engine)
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
                if (iter % 10 == 0)
                {
                    if (y < graphics.ClientHeight - size) y += size;
                    else y += 0;
                }
                iter++;
                
            }return endGame = false;
        }

        public override void Render(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(0xFFFF0000, x, y, size, size);            
        }
    }
}

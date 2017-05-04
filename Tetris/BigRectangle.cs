using NConsoleGraphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class BigRectangle : GameObject
    {
        
        Color color = Color.BigRectanglColor;
        public byte[,] bigRectangl { get; } = new byte[2, 2]
        {
            {1,1 },
            {1,1 }
        };

        public int i = 0;
        public int x { get; set; } = startX;
        public int y { get; set; } = startY;
        public const int size = 25;
        public const int startX = 150;
        public const int startY = 0;
        ConsoleGraphics graphics;

        public BigRectangle(ConsoleGraphics graphics)
        {
            this.graphics = graphics;
        }

        public override void Update(Field Field)
        {
            if (y != graphics.ClientHeight - size * 2)
            {
                if (Input.IsKeyDown(Keys.LEFT))
                {
                    if (x > 0) x -= size;
                    else x += 0;
                }
                else if (Input.IsKeyDown(Keys.RIGHT))
                {
                    if (x < graphics.ClientWidth - size * 2 - 5) x += size;
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
            else
            {
                int fieldX = x;
                int fieldY = y;
                for (int i = 0; i < bigRectangl.GetLength(0); i++)
                {
                    for (int j = 0; j < bigRectangl.GetLength(1); j++)
                    {
                        Field.Rectangles[(fieldY / size)-1, (fieldX / size)-1].Color = color;
                        Field.Rectangles[(fieldY / size)-1, (fieldX / size)-1].CelsValue = bigRectangl[i, j];
                        fieldX += size;
                    }

                    fieldY += size;
                    fieldX = x;
                }
                x = startX;
                y = startY;
            }
        }

        public override void Render(ConsoleGraphics graphics)
        {
            graphics.FillRectangle((uint)color, x, y, size, size);
            graphics.FillRectangle((uint)color, x + size, y, size, size);
            graphics.FillRectangle((uint)color, x, y + size, size, size);
            graphics.FillRectangle((uint)color, x + size, y + size, size, size);
        }
    }
}

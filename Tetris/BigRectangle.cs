using NConsoleGraphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class BigRectangle : IGameObject
    {
        Color color = Color.BigRectanglColor;
        byte[,] bigRectangl = new byte[2, 2]
         {
            {1,1 },
            {1,1 }
         };
        public ConsoleGraphics graphics;
       
        

        public BigRectangle(ConsoleGraphics graphics)
        {
            this.graphics = graphics;
        }

        public void AddFigure(GameEngine engine, IGameObject bigRectangle)
        {
            engine.AddObject(bigRectangle);

        }

        public void DeleteFigure(GameEngine engine, IGameObject bigRectangle)
        {
            engine.DeleteObject(bigRectangle);
        }

        public override bool Update(Field Field,GameEngine engine)
        {
            if (Field.Rectangles[y / size + 1, x / size].CelsValue != 1 && Field.Rectangles[y / size + 1, x / size + 1].CelsValue != 1)
            {
                if (y != graphics.ClientHeight - size * 2 && Field.Rectangles[y / size + 2, x / size].CelsValue != 1 && Field.Rectangles[y / size + 2, x / size + 1].CelsValue != 1)
                {
                    if (Input.IsKeyDown(Keys.LEFT))
                    {
                        if (x > 0 && Field.Rectangles[y / size, x / size - 1].CelsValue == 0 && Field.Rectangles[y / size + 1, x / size - 1].CelsValue == 0) x -= size;
                    }
                    else if (Input.IsKeyDown(Keys.RIGHT))
                    {
                        if (x < graphics.ClientWidth - size * 2 - 5 && Field.Rectangles[y / size, x / size + 2].CelsValue == 0 &&
                            Field.Rectangles[y / size + 1, x / size + 2].CelsValue == 0) x += size;
                    }
                    if (Input.IsKeyDown(Keys.DOWN) || iter % 10 == 0)
                    {
                        if (y <= graphics.ClientHeight - size * 3)
                        {
                            if (Field.Rectangles[y / size + 2, x / size].CelsValue == 0 && Field.Rectangles[y / size + 2, x / size + 1].CelsValue == 0) y += size;
                        }
                        else
                        {
                            if (y < graphics.ClientHeight - size) y += size;
                        }
                    }
                    iter++;
                }
                else
                {
                    int fieldX = x;
                    int fieldY = y;
                    for (int i = 0; i < bigRectangl.GetLength(0); i++)
                    {
                        for (int j = 0; j < bigRectangl.GetLength(1); j++)
                        {
                            Field.Rectangles[fieldY / size, fieldX / size].Color = color;
                            Field.Rectangles[fieldY / size, fieldX / size].CelsValue = bigRectangl[i, j];
                            fieldX += size;
                        }
                        fieldY += size;
                        fieldX = x;
                    }
                    x = startX;
                    y = startY;
                    
                }
                return endGame = true;
            }
            else
            {
                
                return endGame = false;
            }
        }

        public bool EndGame(bool endGame)
        {

            return endGame;
        }

        public override void Render(ConsoleGraphics graphics)
        {
            for (int i = 0; i < bigRectangl.GetLength(0); i++)
            {
                for (int j = 0; j < bigRectangl.GetLength(1); j++)
                {
                    graphics.FillRectangle((uint)color, x + j * size, y + i * size, size, size);
                }
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace Tetris
{
    class L : IGameObject
    {
        Color color = Color.LColor;
        Rectangle[,] LFigure = new Rectangle[3, 3];
        byte[,] Figure = new byte[3, 3]
        {
            {1,0,0 },
            {1,0,0 },
            {1,1,0 }
        };
        int state=1;

        public ConsoleGraphics graphics;

        public L(ConsoleGraphics graphics)
        {
            this.graphics = graphics;
        }

        public void CreatFigure()
        {
            int x = startX;
            int y = startY;
            for (int i = 0; i < LFigure.GetLength(0); i++)
            {
                for (int j = 0; j < LFigure.GetLength(1); j++)
                {
                    LFigure[i, j].CelsValue = Figure[i, j];
                    if (LFigure[i, j].CelsValue == 1) LFigure[i, j].Color = color;
                    else LFigure[i, j].Color = Color.DEfaultColor;
                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            LFigure[i, j].x = x;
                            LFigure[i, j].y = y;
                        }
                        else
                        {
                            LFigure[i, j].x += LFigure[i, j - 1].x + size;

                        }
                    }
                    else
                    {
                        LFigure[i, j].x = LFigure[i - 1, j].x;
                        LFigure[i, j].y = LFigure[i - 1, j].y + size;
                    }
                }

            }
        }

        public override bool Update(Field Field, GameEngine engine)
        {
            if (Input.IsKeyDown(Keys.LEFT))
            {
                if (state == 1)
                {
                    for (int i = 0; i < LFigure.GetLength(0); i++)
                    {
                        for (int j = 0; j < LFigure.GetLength(1); j++)
                        {
                            if (LFigure[i, 0].x > 0)
                            {
                                if (Field.Rectangles[LFigure[i, j].y / size, LFigure[i, j].x / size - 1].CelsValue != 1) LFigure[i, j].x -= size;
                            }
                        }
                    }
                }
            }

            if (Input.IsKeyDown(Keys.RIGHT))
            {
                for (int i = LFigure.GetLength(0) - 1; i >= 0; i--)
                {
                    for (int j = LFigure.GetLength(1) - 1; j >= 0; j--)
                    {
                        if (LFigure[i, j].x < Field.Rectangles[LFigure[i, j].y / size, Field.Rectangles.GetLength(1) - 1].x && Field.Rectangles[LFigure[i, j].y / size, LFigure[i, j].x / size + 1].CelsValue != 1) LFigure[i, j].x += size;
                    }
                }
            }

            if (Input.IsKeyDown(Keys.DOWN) || iter % 10 == 0)
            {
                for (int i = LFigure.GetLength(0) - 1; i >= 0; i--)
                {
                    for (int j = 0; j < LFigure.GetLength(1); j++)
                    {
                        if (Field.Rectangles[LFigure[i, j].y / size + 1, LFigure[i, j].x / size].CelsValue != 1) LFigure[i, j].y += size;
                    }
                }
            }
            iter++;
            return endGame = true;
        }
        //if (Field.Rectangles[y / size + 1, x / size].CelsValue != 1 && Field.Rectangles[y / size + 1, x / size + 1].CelsValue != 1)
        //{
        //    if (y != graphics.ClientHeight - size * 2 && Field.Rectangles[y / size + 2, x / size].CelsValue != 1 && Field.Rectangles[y / size + 2, x / size + 1].CelsValue != 1)
        //    {
        //        if (Input.IsKeyDown(Keys.LEFT))
        //        {
        //            if (x > 0 && Field.Rectangles[y / size, x / size - 1].CelsValue == 0 && Field.Rectangles[y / size + 1, x / size - 1].CelsValue == 0) x -= size;
        //        }
        //        else if (Input.IsKeyDown(Keys.RIGHT))
        //        {
        //            if (x < graphics.ClientWidth - size * 2 - 5 && Field.Rectangles[y / size, x / size + 2].CelsValue == 0 &&
        //                Field.Rectangles[y / size + 1, x / size + 2].CelsValue == 0) x += size;
        //        }
        //        if (Input.IsKeyDown(Keys.DOWN) || i % 10 == 0)
        //        {
        //            if (y <= graphics.ClientHeight - size * 3)
        //            {
        //                if (Field.Rectangles[y / size + 2, x / size].CelsValue == 0 && Field.Rectangles[y / size + 2, x / size + 1].CelsValue == 0) y += size;
        //            }
        //            else
        //            {
        //                if (y < graphics.ClientHeight - size) y += size;
        //            }
        //        }
        //        i++;
        //    }
        //    else
        //    //    {
        //    int fieldX = x;
        //    int fieldY = y;
        //    for (int i = 0; i < LFigure.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < LFigure.GetLength(1); j++)
        //        {
        //            Field.Rectangles[fieldY / size, fieldX / size].Color = LFigure[i, j].Color;
        //            Field.Rectangles[fieldY / size, fieldX / size].CelsValue = LFigure[i, j].CelsValue;
        //            fieldX += size;
        //        }
        //        fieldY += size;
        //        fieldX = x;
        //    }
        //    x = startX;
        //    y = startY;

        //    return endGame = true;
        //}
        //else
        //{
        //    return endGame = false;
        //}

        //    if(i%10==0)
        //    {
        //        for (int i = LFigure.GetLength(0)-1; ;)
        //        {
        //            for (int j = 0; j < LFigure.GetLength(1); j++)
        //            {
        //                if (y<=graphics.ClientHeight-size*4)
        //                {
        //                    if (Field.Rectangles[,] )
        //                        y += size;
        //                }
        //            }

        //        }
        //    }
        //    i++;
        //    return endGame = true;
        //}

        public override void Render(ConsoleGraphics graphics)
        {
            for (int i = 0; i < LFigure.GetLength(0); i++)
            {
                for (int j = 0; j < LFigure.GetLength(1); j++)
                {
                    graphics.FillRectangle((uint)LFigure[i, j].Color, LFigure[i, j].x, LFigure[i, j].y, size, size);
                }
            }
        }
    }
}

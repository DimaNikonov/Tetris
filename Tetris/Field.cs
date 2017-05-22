using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace Tetris
{
    class Field
    {
        ConsoleGraphics graphics;

        public uint Score=0;
        public const int size = 25;
        public Rectangle[,] Rectangles;

        public void FillField(ConsoleGraphics graphics)
        {
            int sizeX = graphics.ClientWidth / size;
            int sizeY = graphics.ClientHeight / size;
            Rectangles = new Rectangle[sizeY, sizeX];
            for (int i = 0; i < Rectangles.GetLength(0); i++)
            {
                for (int j = 0; j < Rectangles.GetLength(1); j++)
                {
                    Rectangles[i, j].CelsValue = 0;
                    Rectangles[i, j].Color = Color.DEfaultColor;
                    Rectangles[i, j].x = j * size;
                    Rectangles[i, j].y = i * size;
                }
            }
        }

        public Field(ConsoleGraphics graphics)
        {
            this.graphics = graphics;
        }

        public void ClearLine()
        {
            List<int> numberLine = new List<int>();
            bool fillLine = false;
            for (int i = 0; i < Rectangles.GetLength(0); i++)
            {
                for (int j = 0; j < Rectangles.GetLength(1); j++)
                {
                    if (Rectangles[i, j].CelsValue != 0) fillLine = true;
                    else
                    {
                        fillLine = false;
                        break;
                    }
                    if (j == Rectangles.GetLength(1) - 1 && fillLine == true) numberLine.Add(i);
                }
            }         
          
            int k = 0;
            while (k < numberLine.Count)
            {
                for (int i = 0; i < Rectangles.GetLength(1); i++)
                {
                    Rectangles[numberLine[k], i].CelsValue = 0;
                    Rectangles[numberLine[k], i].Color = Color.DEfaultColor;
                }

                for (int i = numberLine[k]; i >= 1; i--)
                {
                    for (int j = 0; j < Rectangles.GetLength(1); j++)
                    {
                        Rectangles[i, j].CelsValue = Rectangles[i - 1, j].CelsValue;
                        Rectangles[i, j].Color = Rectangles[i - 1, j].Color;
                    }
                }
                for (int i = 0; i < Rectangles.GetLength(1); i++)
                {
                    Rectangles[0, i].CelsValue = 0;
                    Rectangles[0, i].Color = Color.DEfaultColor;
                }

                k++;
            }
        }
    }
}

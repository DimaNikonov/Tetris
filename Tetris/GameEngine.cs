using NConsoleGraphics;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Tetris
{
    abstract class GameEngine
    {
        Random rnd = new Random();
        public ConsoleGraphics graphics;
        
        private List<IGameObject> objects = new List<IGameObject>();
        private List<IGameObject> tempObjects = new List<IGameObject>();
        public GameEngine(ConsoleGraphics graphics)
        {
            this.graphics = graphics;
        }

        public void AddObject(IGameObject obj)
        {
            objects.Add(obj);
        }

        public void DeleteObject(IGameObject obj)
        {
            objects.Remove(obj);
        }

        public void Start(Field Field,GameEngine engine)
        {
            int indexObject = rnd.Next(0, objects.Count);
            bool gameState = true;
            while (gameState)
            {
                //foreach (var item in gameObject)
                //{
                objects[indexObject].Update(Field, engine);
                gameState = objects[indexObject].endGame;
                //}

                Field.ClearLine();
                graphics.FillRectangle(0xFFFFFFFF, 0, 0, graphics.ClientWidth, graphics.ClientHeight);

                for (int i = 0; i < Field.Rectangles.GetLength(0); i++)
                {
                    for (int j = 0; j < Field.Rectangles.GetLength(1); j++)
                    {
                        graphics.FillRectangle((uint)Field.Rectangles[i, j].Color, Field.Rectangles[i, j].x, Field.Rectangles[i, j].y, Field.size, Field.size);
                    }
                }

                //foreach (var item in gameObject)
                //{
                objects[indexObject].Render(graphics);
                //}

                graphics.FlipPages();
                Thread.Sleep(25);
            }
        }
    }
}
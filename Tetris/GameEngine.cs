using NConsoleGraphics;
using System.Collections.Generic;
using System.Threading;

namespace Tetris
{
    abstract class GameEngine
    {
        //public Field Field;
        public ConsoleGraphics graphics;
        public List<GameObject> gameObject = new List<GameObject>();

        public GameEngine(ConsoleGraphics graphics)
        {
            this.graphics = graphics;
        }

        public void AddObject(GameObject obj)
        {
            gameObject.Add(obj);
        }

        public void Start(Field Field)
        {
            while (true)
            {
                foreach (var item in gameObject)
                {
                    item.Update(Field);
                }

                graphics.FillRectangle(0xFFFFFFFF, 0, 0, graphics.ClientWidth, graphics.ClientHeight);
                
                foreach (var item in gameObject)
                {
                    item.Render(graphics);
                    Field.Render(graphics);
                }

                graphics.FlipPages();
                Thread.Sleep(25);
            }
        }

    }
}
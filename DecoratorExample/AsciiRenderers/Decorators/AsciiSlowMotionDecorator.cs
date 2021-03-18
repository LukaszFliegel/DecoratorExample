using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DecoratorExample.AsciiRenderers.Decorators
{
    public class AsciiSlowMotionDecorator : IAsciiRenderer
    {
        private readonly IAsciiRenderer _decoratedObject;

        public AsciiSlowMotionDecorator(IAsciiRenderer decoratedObject)
        {
            _decoratedObject = decoratedObject;
        }

        public void Draw()
        {
            Console.WriteLine("5...");
            Thread.Sleep(400);
            Console.WriteLine("4...");
            Thread.Sleep(400);
            Console.WriteLine("3...");
            Thread.Sleep(400);
            Console.WriteLine("2...");
            Thread.Sleep(400);
            Console.WriteLine("1...");
            Thread.Sleep(400);

            _decoratedObject.Draw();
        }
    }
}

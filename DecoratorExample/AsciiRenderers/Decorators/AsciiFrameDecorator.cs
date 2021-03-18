using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorExample.AsciiRenderers.Decorators
{
    public class AsciiFrameDecorator : IAsciiRenderer
    {
        private readonly IAsciiRenderer _decoratedObject;

        public AsciiFrameDecorator(IAsciiRenderer decoratedObject)
        {
            _decoratedObject = decoratedObject;
        }

        public void Draw()
        {
            Console.WriteLine("====================================================================");

            _decoratedObject.Draw();

            Console.WriteLine("====================================================================");
        }
    }
}

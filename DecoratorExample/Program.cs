using DecoratorExample.AsciiProviders;
using DecoratorExample.AsciiRenderers;
using DecoratorExample.AsciiRenderers.Decorators;
using System;

namespace DecoratorExample
{
    class Program
    {

        static void Main(string[] args)
        {
            //DrawAsciiText();
            //DrawAsciiTextWithFrame();
            //DrawAsciiTextWithSlowMotion();
            //DrawAsciiTextWithSlowMotionInFrame();
            DrawAsciiTextWithFrameWithSlowMotion();

            Console.ReadKey();
        }

        private static void DrawAsciiText()
        {
            var asciiProvider = new FileAsciiProvider("AsciiIcons/Text.txt");

            var asciiRednerer = new AsciiRenderer(asciiProvider.GetAscii());
            asciiRednerer.Draw();
        }

        private static void DrawAsciiTextWithFrame()
        {
            var asciiProvider = new FileAsciiProvider("AsciiIcons/Text.txt");

            var asciiRenderer = new AsciiRenderer(asciiProvider.GetAscii());
            var frameDecorator = new AsciiFrameDecorator(asciiRenderer);
            frameDecorator.Draw();
        }

        private static void DrawAsciiTextWithSlowMotion()
        {
            var asciiProvider = new FileAsciiProvider("AsciiIcons/Text.txt");

            var asciiRenderer = new AsciiRenderer(asciiProvider.GetAscii());
            var slowMotionDecorator = new AsciiSlowMotionDecorator(asciiRenderer);
            slowMotionDecorator.Draw();
        }

        private static void DrawAsciiTextWithSlowMotionInFrame()
        {
            var asciiProvider = new FileAsciiProvider("AsciiIcons/Text.txt");

            var asciiRenderer = new AsciiRenderer(asciiProvider.GetAscii());
            var slowMotionDecorator = new AsciiSlowMotionDecorator(asciiRenderer);
            var frameDecorator = new AsciiFrameDecorator(slowMotionDecorator);
            frameDecorator.Draw();
        }

        private static void DrawAsciiTextWithFrameWithSlowMotion()
        {
            var asciiProvider = new FileAsciiProvider("AsciiIcons/Text.txt");

            var asciiRenderer = new AsciiRenderer(asciiProvider.GetAscii());
            var frameDecorator = new AsciiFrameDecorator(asciiRenderer);
            var slowMotionDecorator = new AsciiSlowMotionDecorator(frameDecorator);
            slowMotionDecorator.Draw();
        }
    }
}

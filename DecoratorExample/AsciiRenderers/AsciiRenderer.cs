using System;

namespace DecoratorExample.AsciiRenderers
{
    public class AsciiRenderer : IAsciiRenderer
    {
        private readonly char[][] _imageCharacters;

        public AsciiRenderer(char[][] imageCharacters)
        {
            _imageCharacters = imageCharacters;
        }

        public virtual void Draw()
        {
            for (int i = 0; i < _imageCharacters.Length; i++)
            {
                for (int j = 0; j < _imageCharacters[i].Length; j++)
                {
                    Console.Write(_imageCharacters[i][j]);
                }

                Console.WriteLine();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DecoratorExample.AsciiProviders
{
    public class FileAsciiProvider : AsciiProvider
    {
        private readonly string _asciFilePath;

        public FileAsciiProvider(string asciFilePath)
        {
            _asciFilePath = asciFilePath;
        }

        public override char[][] GetAscii()
        {
            var fileLines = File.ReadAllLines(_asciFilePath);

            char[][] charactersFromFile = new char[fileLines.Length][];

            for (int i = 0; i < fileLines.Length; i++)
            {
                charactersFromFile[i] = fileLines[i].ToCharArray();
            }

            return charactersFromFile;
        }
    }
}

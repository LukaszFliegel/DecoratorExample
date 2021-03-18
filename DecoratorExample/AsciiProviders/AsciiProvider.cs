using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorExample.AsciiProviders
{
    public abstract class AsciiProvider
    {
        public abstract char[][] GetAscii();
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddAddBookJson15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CsvJsonHandler.ImplementCSVDataHandling();
            JsonHandler.ImplementJSON();
        }
    }
}

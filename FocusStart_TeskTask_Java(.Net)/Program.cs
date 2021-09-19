using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace FocusStart_TeskTask_Java_.Net_
{
    class Program
    {      
        static void Main(string[] args)
        {
            new MergeFileProgram().Run(args);

            Console.ReadKey();
            
        }

    }
}

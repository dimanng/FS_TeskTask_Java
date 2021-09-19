using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusStart_TeskTask_Java_.Net_
{
    public class FileMetaData
    {
        public string Line { get; set; }
        public string LinePrev { get; set; }
        public string FileName { get; set; }
        public ICompare Comparer { get; set; }

        public void MergeLine(StreamReader reader, StreamWriter writer)
        {
            if (Comparer.isNotCorrectOrder(LinePrev, Line))
            {
                Line = null;
                Console.WriteLine("Файл {0} поврежден после элемента {1}, дальнейшие данные не учитываются", FileName, LinePrev);
            }
            else
            {
                writer.WriteLine(Line);
                LinePrev = Line;
                Line = reader.ReadLine();
            }
        }
    }
}

using System;
using System.Collections;
using System.IO;

namespace FocusStart_TeskTask_Java_.Net_
{
    public class FileHelper
    {
        public void RemoveNotExistFiles(ArrayList arrFiles)
        {
            for (int i = 1; i < arrFiles.Count; i++)
            {
                if (!File.Exists(arrFiles[i].ToString()))
                {
                    Console.WriteLine("Файл {0} не найден", arrFiles[i]);
                    arrFiles.RemoveAt(i);
                    i--;
                }              
            }
            if (arrFiles.Count == 1)
            {
                Console.WriteLine("Укажите входные файлы и перезапустите программу");
                Console.WriteLine("Нажмите любую клавишу для завершения работы...");
                Console.ReadKey();
                Environment.Exit(0);
            }
            if (arrFiles.Count == 0)
            {
                Console.WriteLine("Укажите входной и выходные файлы и перезапустите программу");
                Console.WriteLine("Нажмите любую клавишу для завершения работы...");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        public void RemoveFile(string filename)
        {
            if (filename != null)
            {
                File.Delete(filename);
            }
        }

        public void RemoveFileByMask(string mask)
        {
            foreach (string temp in Directory.GetFiles(".\\", mask))
            {
                File.Delete(temp);
            }
        }
        
    }
}

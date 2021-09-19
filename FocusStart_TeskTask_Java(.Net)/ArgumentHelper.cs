using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace FocusStart_TeskTask_Java_.Net_
{
    public class ArgumentHelper
    {
        private ArrayList arguments = new ArrayList() { "-i", "-s", "-a", "-d" };

        public ArrayList ExtractArguments(string[] args)
        {
            var arrArgs = new ArrayList();

            foreach (string e in args)
            {
                if (Regex.IsMatch(e, @"-(\w*)"))
                {
                    arrArgs.Add(e);
                }
                
            }
            CheckArgs(arrArgs);
            return arrArgs;
        }

        public ArrayList ExtractNameFiles(string[] args)
        {
            var arrFiles = new ArrayList();
            
            foreach(string e in args)
            {
                if (Regex.IsMatch(e, @"\w*\.\w*"))
                {
                    arrFiles.Add(e);
                }
            }
            return arrFiles;
        }

        private void CheckArgs(ArrayList arrArgs)
        {
            foreach (string e in arrArgs)
            {
                if (!arguments.Contains(e))
                {
                    Console.WriteLine("Неизвестный аргумент {0}", e);
                    Console.WriteLine("Доступные аргументы:");
                    Console.WriteLine("-i для сортировки чисел, -s для сортировки строк");
                    Console.WriteLine("-d для сортировки по возрастанию, -d для сортировки по убыванию");
                    Console.WriteLine("Нажмите любую клавишу для завершения работы...");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
            if(arrArgs.Count == 0)
            {
                Console.WriteLine("Укажите аргументы и перезапустите программу");
                Console.WriteLine("Нажмите любую клавишу для завершения работы...");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
       
}
}

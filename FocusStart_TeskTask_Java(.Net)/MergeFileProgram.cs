using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace FocusStart_TeskTask_Java_.Net_
{
    public class MergeFileProgram
    {
        private ArgumentHelper argumentHelper = new ArgumentHelper();

        private FileHelper fileHelper = new FileHelper();

        private string tempFileMask = "Temp*.txt";
        public void Run(string[] args)
        {
            var arrFiles = argumentHelper.ExtractNameFiles(args);

            var arrArgs = argumentHelper.ExtractArguments(args);

            fileHelper.RemoveNotExistFiles(arrFiles);

            ICompare comparer = new CompareFactory().CreateComparerByArguments(arrArgs);

            string pathInNext;
            string pathOut = arrFiles[0].ToString();
            string tempFile = null;

            fileHelper.RemoveFile(pathOut);

            fileHelper.RemoveFileByMask(tempFileMask);

            tempFile = MergeFiles(arrFiles, comparer);

            if (tempFile != null)
            {
                File.Move(tempFile, pathOut);
            }

            fileHelper.RemoveFileByMask(tempFileMask);

            Console.WriteLine("Сортировка выполнена, результат находится в файле {0}", pathOut);

            Process.Start(new ProcessStartInfo(pathOut) { UseShellExecute = true });
        }

        private string MergeFiles(ArrayList arrFiles, ICompare comparer)
        {
            string pathInNext;
            int k = 0;
            string pathIn;
            string tempFile = null;


            for (int i = 0; i < arrFiles.Count - 1; i++)
            {
                if (arrFiles.Count == 2)
                {
                    pathIn = arrFiles[1].ToString();
                    tempFile = @"temp" + k + ".txt";
                    k++;

                    using (StreamWriter writer = new StreamWriter(tempFile))
                    {
                        using (StreamReader reader = new StreamReader(pathIn))
                        {
                            FileMetaData File1 = new FileMetaData();

                            File1.FileName = pathIn;
                            File1.Comparer = comparer;

                            File1.Line = reader.ReadLine();

                            File1.LinePrev = File1.Line;

                            while (File1.Line != null)
                            {
                                File1.MergeLine(reader, writer);
                            }

                            pathIn = tempFile;
                        }
                    }
                }
                else
                {
                    pathIn = arrFiles[1].ToString();

                    pathInNext = arrFiles[i + 1].ToString();


                    tempFile = @"temp" + k + ".txt";
                    k++;

                    using (StreamWriter writer = new StreamWriter(tempFile))
                    {

                        using (StreamReader reader1 = new StreamReader(pathIn))
                        {
                            FileMetaData File1 = new FileMetaData();
                            FileMetaData File2 = new FileMetaData();

                            File1.FileName = pathIn;
                            File2.FileName = pathInNext;

                            File1.Comparer = comparer;
                            File2.Comparer = comparer;

                            using (StreamReader reader2 = new StreamReader(pathInNext))
                            {
                                File1.Line = reader1.ReadLine();
                                File2.Line = reader2.ReadLine();

                                File1.LinePrev = File1.Line;
                                File2.LinePrev = File2.Line;

                                while (File1.Line != null || File2.Line != null)
                                {
                                    if (File1.Line == null)
                                    {
                                        File2.MergeLine(reader2, writer);
                                    }
                                    else if (File2.Line == null)
                                    {
                                        File1.MergeLine(reader1, writer);
                                    }
                                    else if (comparer.isNextValid(File1.Line, File2.Line))
                                    {
                                        File1.MergeLine(reader1, writer);
                                    }
                                    else
                                    {
                                        File2.MergeLine(reader2, writer);
                                    }
                                }
                            }
                            pathIn = tempFile;
                        }
                    }
                }
            }
            return tempFile;
        }
    }
}

using System;
using System.IO;

namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dirInf;

            string dirpath = null;

            do
            {
                Console.WriteLine("Введите корректный путь до каталога - ");
                dirpath = Console.ReadLine();

                if ((isDirectoryNameValid(dirpath) == true) & Directory.Exists(dirpath))
                {
                    //Console.WriteLine("Yep");
                    break;
                }
                else
                    Console.WriteLine("Введен некорректный путь!");
            } while (true);

            dirInf = new DirectoryInfo(dirpath);

            try
            {
                foreach (var directory in dirInf.GetDirectories())
                {
                    if (Directory.GetLastAccessTime(directory.FullName).Minute > TimeSpan.FromMinutes(30).TotalMinutes)
                    {
                        directory.Delete(true);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Косяк - " + e);
            }
        }
        static bool isDirectoryNameValid(string dirName)
        {
            if ((dirName == null) || (dirName.IndexOfAny(Path.GetInvalidPathChars()) != -1))
                return false;
            try
            {                
                return true;
            }
            catch (NotSupportedException)
            {
                return false;
            }
        }
    }
}

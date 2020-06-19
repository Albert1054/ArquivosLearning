using System;
using System.IO;
using System.Security;
using System.Globalization;
using ArquivoLerning.Entities;
using System.Collections.Generic;

namespace ArquivoLerning
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full path: ");
            string sourcePath = Console.ReadLine();
            List<Product>list = new List<Product>();

            try
            {
                string targetPath = Path.GetDirectoryName(sourcePath) + @"\out\summary.csv";
                Console.WriteLine(targetPath);
                using (StreamReader sr = File.OpenText(sourcePath))
                {
                    while (!sr.EndOfStream)
                    {
                        list.Add(new Product(sr.ReadLine().Split(",")));
                    }
                    Directory.CreateDirectory(Path.GetDirectoryName(sourcePath) + @"\out");
                    using (StreamWriter sw = File.AppendText(targetPath))
                    {
                        foreach(Product p in list)
                        {
                            sw.WriteLine(p);
                        }
                    }
                }
                
            }
            catch(IOException e)
            {
                Console.WriteLine("An error has occurred!");
                Console.WriteLine(e.Message);
            }
        }
    }
}

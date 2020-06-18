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
            string sourcePath = @"C:\Users\caval\Documents\temp\Origem.csv";
            string targetPath = @"C:\Users\caval\Documents\temp\out\summary.csv";
            List<Product>list = new List<Product>();

            try
            {
                using (StreamReader sr = File.OpenText(sourcePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] lines = sr.ReadLine().Split(",");
                        string name = lines[0];
                        double price = double.Parse(lines[1],CultureInfo.InvariantCulture);
                        Console.WriteLine(price);
                        int quantity = int.Parse(lines[2]);
                        list.Add(new Product(name,price,quantity));
                    }
                    Directory.CreateDirectory(Path.GetDirectoryName(sourcePath) + @"\out");
                    using (StreamWriter sw = File.AppendText(targetPath))
                    {
                        foreach(Product p in list)
                        {
                            sw.WriteLine(p.Name + ", " +p.Total().ToString("F2",CultureInfo.InvariantCulture));
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

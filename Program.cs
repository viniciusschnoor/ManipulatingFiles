using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ManipulatingFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Creating a path file
             * string path1 = "C:\\Users\\vschn\\OneDrive\\Imagens\\Saved Pictures";
             * OR
             * string path2 = @"C:\Users\vschn\OneDrive\Imagens\Saved Pictures";
             */
            string path1 = @"C:\Users\vschn\source\repos\ManipulatingFiles\test.txt";
            string path2 = @"C:\Users\vschn\Downloads\test.txt";
            /*
             * Verifing if a file exists
             */
            bool existFile = File.Exists(path1);
            if (existFile)
            {
                Console.WriteLine("The file exists");
                File.Delete(path1); // Deleting
                Console.WriteLine("File just be deleted");
            }
            else
            {
                Console.WriteLine("The file don't exists");
                FileStream myFile = File.Create(path1); // Creating
                myFile.Close(); // Closing to use
                Console.WriteLine("File just be created!");
                try
                {
                    File.Move(path1, path2); // Moving
                }
                catch (System.IO.IOException ex)
                {
                    Console.WriteLine(ex.Message);
                    File.Delete(path1);
                }
                finally
                {
                    string content = "Vinicius Schnoor \r\nGiovanna Maria";
                    File.WriteAllText(path2, content); // Writing in file
                    /*
                     * Writing a string array
                     */
                    string[] arrayContent = { "Vinicius", "Schnoor", "F", "Santos"};
                    File.WriteAllLines(path2, arrayContent);
                }
                string readFile = File.ReadAllText(path2); // Reading file
                Console.WriteLine(readFile);

                string[] allContent = File.ReadAllLines(path2);
                foreach(string line in allContent)
                {
                    Console.WriteLine(line);
                }
            }
            Console.ReadKey(true);
        }
    }
}

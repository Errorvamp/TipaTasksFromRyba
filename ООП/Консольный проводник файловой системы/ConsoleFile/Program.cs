using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFile
{
    internal class Program
    {
        private string path;
        private string searchinfile;
        static string currentDir;

        static void Main(string[] args)
        {
            currentDir = Environment.CurrentDirectory;
            bool running = true;

            while (running)
            {
                Console.Clear();
                Program program = new Program();
                Console.WriteLine("Enter filename:");
                program.searchinfile = Convert.ToString(Console.ReadLine());

                string[] directory = Directory.GetDirectories("C:");
                foreach (string d in directory)
                {
                    program.path = d;
                    Console.WriteLine(program.path);
                }
                Console.WriteLine("Choose option: Copy, Create, Delete, Move, Exit ");
                Console.Write("> ");

                string input = Console.ReadLine().Trim().ToUpper();
                    switch (input)
                    {
                    case "Copy": Copy(); break;
                    case "Create": Create(); break;
                    case "Delete": Delete(); break;
                    case "Move": Move(); break;
                    case "Exit": running = false; break;
                        default:
                            Console.WriteLine("Ошибка ввода. Нажмите на любую клавишу...");
                            Console.ReadKey();
                            break;
                    }
            }
        }
            static void Copy(string currentDir)
            {
            string newPath = @"C:\NewDir\index2.txt";
                FileInfo fileInf = new FileInfo(currentDir);
                if (fileInf.Exists)
                {
                    fileInf.CopyTo(newPath, true);
                }
            }
            static void Create(string currentDir)
            {
                Console.Write("Введите название: ");
                string name = Convert.ToString(Console.ReadLine());
                if (string.IsNullOrEmpty(name)) { name = "name"; };

                Console.WriteLine("Можете ввести содержимое");
                string content = Console.In.ReadToEnd();
                try
                {
                    File.WriteAllText(Path.Combine(path, name), content);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.ReadKey();
                }
        }
            static void Delete(string path)
            {
            FileInfo fileInf = new FileInfo(path);
                if (fileInf.Exists)
                {
                    fileInf.Delete();
                }
            }
            static void Move(string path)
            {
                string newPath = @"C:\NewDir\index.txt";
                FileInfo fileInf = new FileInfo(path);
                if (fileInf.Exists)
                {
                    fileInf.MoveTo(newPath);
                }
            }

            static void Exists()
            {

            }
            static void Read(string path)
            {
                Console.Clear();
                try
                {
                    Console.WriteLine(File.ReadAllText(path));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                Console.WriteLine("\nНажмите на любую клавишу...");
                Console.ReadKey();
            }
        }
        
    }
}

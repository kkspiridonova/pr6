using System.ComponentModel.Design;
using System.IO;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace Конвертер
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            string Text = " ";
            string txt = ".txt";
            string json = ".json";
            string xml = ".xml";

            Figure one = new Figure();
            one.Name = "Прямоугольник";
            one.Dlina = 45;
            one.Shirina = 11;

            Figure two = new Figure();
            two.Name = "Квадрат";
            two.Dlina = 15;
            two.Shirina = 15;

            Figure three = new Figure();
            three.Name = "Прямоугольник";
            three.Dlina = 13;
            three.Shirina = 17;

            List<Figure> list = new List<Figure>();
            list.Add(one);
            list.Add(two);
            list.Add(three);


            Console.WriteLine("Введите путь до файла");
            string path = Console.ReadLine();

            Console.Clear();

            if (path.EndsWith(txt))
            {
               Text = ReadingOrSaving.ReadTxt(path);
            }

            else if (path.EndsWith(json))
            {
               Text = ReadingOrSaving.ReadJson(path);
               
            }
            else if (path.EndsWith(xml))
            {
                Text = ReadingOrSaving.ReadXml(path);
            }

            Console.WriteLine("F1 - сохранить, Esc - выйти");
            while (true)
            {
                ConsoleKeyInfo option = Console.ReadKey();
                if (option.Key == ConsoleKey.F1)
                {
                    Console.Clear();

                    while (option.Key != ConsoleKey.Escape)
                    {
                        Console.WriteLine("Введите путь файла, куда сохранить");
                        string savepath = Console.ReadLine();
                        if (savepath.EndsWith(txt))
                        {
                            ReadingOrSaving.WriteTxt(savepath, Text);
                            Console.WriteLine("Данные сохранены.");
                            break;
                        }
                        else if (savepath.EndsWith(json))
                        {
                            ReadingOrSaving.WriteJson(savepath, list);
                            Console.WriteLine("Данные сохранены.");
                            break;
                        }
                        else if (savepath.EndsWith(xml))
                        {
                            ReadingOrSaving.WriteXml(savepath, list);
                            Console.WriteLine("Данные сохранены.");
                            break;
                        }
                    } 
                }
                else if (option.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }
}
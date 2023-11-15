using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace Конвертер
{
    public class ReadingOrSaving
    {
        public static string ReadTxt(string path)
        {
            string Text = File.ReadAllText(path);
            Console.WriteLine(Text);
            return Text;
        }
        public static void WriteTxt(string savepath, string Text)
        {
            File.WriteAllText(savepath, Text);
        }


        public static string ReadJson(string path)
        {
            string Text = " ";
            string Textjson = File.ReadAllText(path);
            List<Figure> listjson = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Figure>>(Textjson);
            foreach (var item in listjson)
            {
                Text += '\n' + item.Name + '\n' + item.Dlina + '\n' + item.Shirina;
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Dlina);
                Console.WriteLine(item.Shirina);
            }
            return Text;
        }

        public static void WriteJson(string savepath, List<Figure>list) 
        {
            string save = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            File.WriteAllText(savepath, save);
        }

        public static string ReadXml(string path) 
        {
            string Text = " ";
            List<Figure> listxml = new List<Figure>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Figure>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                listxml = (List<Figure>)serializer.Deserialize(fs);
            }
            foreach (var item in listxml)
            {

                Text += '\n' + item.Name + '\n' + item.Dlina + '\n' + item.Shirina;
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Dlina);
                Console.WriteLine(item.Shirina);
            }
            return Text;
        }

        public static void WriteXml (string savepath, List<Figure> list)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Figure>));
            using (FileStream fs = new FileStream(savepath, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, list);
            }
        }
    }
}

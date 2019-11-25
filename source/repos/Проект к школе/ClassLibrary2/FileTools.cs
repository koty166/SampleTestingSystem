using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClassLibrary2
{
    static public class FileTools
    {
       // static readonly string Directory = @"Tests";
        static public void Clear()
        {
            if(File.Exists( "log.log"))
                File.Create("log.log").Close();
        }
        static public void Log(String Message)
        {
            if(!File.Exists("log.log"))
                File.Create( "log.log").Close();

            StreamWriter w = new StreamWriter( "log.log" ,true);
            w.WriteLine(DateTime.Now +":" + DateTime.Now.Millisecond + "\t\t" + Message);
            w.Close();
        }
        static public void Log(String Message , String Path)
        {
            if (!File.Exists(Path))
                File.Create(Path).Close();

            StreamWriter w = new StreamWriter(Path, true);
            w.WriteLine(DateTime.Now + ":" + DateTime.Now.Millisecond + "\t\t" + Message);
            w.Close();
        }
        static public void Save(Object ob, String Path)
        {
            BinaryFormatter b = new BinaryFormatter();
            FileStream f = new FileStream(Path,FileMode.Create);
            b.Serialize(f,ob);
            f.Close();
        }
        static public void Save(Object ob)
        {
            BinaryFormatter b = new BinaryFormatter();
            if (!Directory.Exists("Saves")) Directory.CreateDirectory("Saves");
            string s = "Saves//" + DateTime.Today.ToShortDateString() + ".sav";
            FileStream f = new FileStream(s,FileMode.Create);
            b.Serialize(f,ob);
            f.Close();
        }

    }
}

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Tools
{
    static public class FileTools
    {
        /// <summary>
        /// Очищает файл. Не перехватывает исключения
        /// </summary>
        /// <param name="Path">Путь до файла, включая название файла и его расширение</param>
        /// <param name="Create">Создавать ли файл, елси его не сушествует</param>
        static public void ClearLog(String Path = "Log.log",bool Create = true)
        {

                if (File.Exists(Path))
                {
                    StreamWriter w = new StreamWriter(Path, false);
                    w.WriteLine("");
                    w.Close();
                }
                if (Create)
                    File.Create(Path);

        }

        /// <summary>
        /// Записывает сообщение в файл лога Log.log, находящийся в директории с приложением. Перехватывает исключения.
        /// Текст исключения записывается в Console
        /// </summary>
        /// <param name="Message">Сообщение для записи</param>
        /// <param name="IsAddEnd">Перезапись или добавление в конец файла</param>
        static public void Log(String Message, bool IsAddEnd = true) =>
            Log(Message, "Log.log", IsAddEnd);

        /// <summary>
        /// Записывает сообщение в файл лога. Перехватывает исключения.
        /// Текст исключения записывается в Console
        /// </summary>
        /// <param name="Message">Сообщение для записи</param>
        /// <param name="Path">Путь файла</param>
        /// <param name="IsAddEnd">Перезапись или добавление в конец файла</param>
        static public void Log(String Message, String Path, bool IsAddEnd = true)
        {
            try
            {
                if (!File.Exists(Path))
                    File.Create(Path).Close();

                StreamWriter w = new StreamWriter(Path, IsAddEnd);
                w.WriteLine(DateTime.Now + ":" + DateTime.Now.Millisecond + "\t\t" + Message);
                w.Close();
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
        }

        /// <summary>
        /// Сохраняет объект в файл. Перехватывает исключения.
        /// Текст исключения записывается в Console
        /// </summary>
        /// <param name="ob">Объект для записи</param>
        /// <param name="Path">Путь для записи</param>
        /// <param name="Mode">Режим записи в файл</param>
        static public void Save(Object ob, String Path,FileMode Mode = FileMode.Create)
        {
            try
            {
                BinaryFormatter b = new BinaryFormatter();
                FileStream f = new FileStream(Path, Mode);
                b.Serialize(f, ob);
                f.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        /// <summary>
        /// Сохраняет объект в папку Saves текущей директории. Не перехватывает исключения. Все исключения <see cref="Directory.CreateDirectory(string)">Directory.CreateDirectory</see>
        /// </summary>
        /// <param name="ob">Объект для записи</param>
        /// <param name="Mode">Режим сохразаписив файл</param>
        static public void Save(Object ob, FileMode Mode = FileMode.Create)
        {
                int m = 0;
                string s;
                if (!Directory.Exists("Saves")) Directory.CreateDirectory("Saves");
                while (true)
                {
                    s = "Saves//" + DateTime.Today.ToShortDateString() + m + ".sav";
                    if (File.Exists(s))
                        m++;
                    else break;
                }
            Save(ob,s,Mode);
        }

    }
}

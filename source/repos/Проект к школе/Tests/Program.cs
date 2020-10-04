using System;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using ClassLibrary2.Security;
using System.Threading;
using ClassLibrary2;
namespace Tests
{
    class Program
    {

        static void Main(string[] args)
        {

            string s = "";
            Random r = new Random();
            for (int wi = 0; wi < 100; wi++)
            {
                s += r.Next(1, 101).ToString() + " ";
            }
            StreamWriter sw = new StreamWriter("r.txt", false);
            sw.WriteLine(s);
            sw.Close();

        }
    }
}
                  
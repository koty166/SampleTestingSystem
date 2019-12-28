using System;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using ClassLibrary2.Security;
using ClassLibrary2;
namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {

            Pupil p = new Pupil()
            {
                Age = 15,
                Form = 10,
                Name = "Name",
                Surname = "Surname",
                Patronymic = "Patronymic",
            };
            p.args[4] = "arg4";
            p.args[3] = "arg3";

            for (int i = 0; i < 10; i++)
            {
                p.AnswerList.Add($"Ответ{i}");
            }
            byte[] mass =  EncryptClass.Encrypt(p,new byte[] {25,25,25,26,45,84 });

            Pupil endpup = (Pupil)DecryptClass.Decrypt(mass, new byte[] { 25, 25, 25, 26, 45, 84 });

            Console.ReadLine();
        }
    }
}

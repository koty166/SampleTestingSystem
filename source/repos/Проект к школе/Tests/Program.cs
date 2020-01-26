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
            DateTime t1 ,t2;
            byte[] Key = new byte[256];
            byte BufByte;
            int Lenght = 0;
            // for (int k = 0; k < 200; k++)
            // {
            FileTools.Clear();
                
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
                Random r = new Random();
                for (int i = 0; i < 100; i++)
               {
                t1 = DateTime.Now;
                for (int j = 0; j < 256; j++)
                        Key[j] = (byte)r.Next(0, 64);

                    for (int j = 0; j < 256; j++)
                    {
                        BufByte = (byte)(63 - Key[j]);
                        Key[j] = BufByte;
                    }

                    byte[] mass = EncryptClass.Encrypt(p, Key, ref Lenght);

                    Pupil endpup = (Pupil)DecryptClass.Decrypt(mass, Key);
                t2 = DateTime.Now;
                FileTools.Log("done " + (t2.Second - t1.Second) + ":" + ((t2.Millisecond - t1.Millisecond) < 0 ? 1000 + (t2.Millisecond - t1.Millisecond) : (t2.Millisecond - t1.Millisecond)));
            }
                
                
            //}
            Console.ReadLine();
        }
    }
}

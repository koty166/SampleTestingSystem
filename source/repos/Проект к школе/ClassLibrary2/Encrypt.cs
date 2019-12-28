using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading;

namespace ClassLibrary2.Security
{
    public class EncryptClass
    {
        static byte[] EncryptBlock(byte b, byte key , int seed)
        {
            byte[] mas = new byte[128];
            Random r = new Random(seed);

            for (int i = 0; i < 128; i++)
                mas[i] = (byte)r.Next(0, 256);

            mas[key] = b;
            return mas;
        }

        public static byte[] Encrypt(Pupil p, byte[] key)
        {
            byte[] mas , Out;
            int l = 0;
            List<byte[]> List = new List<byte[]>();

            BinaryFormatter b = new BinaryFormatter();
            MemoryStream s = new MemoryStream();
            b.Serialize(s,p);

            mas = s.ToArray();

            for (int i = 0; i < mas.Length; i++)
            {
                if (l == key.Length) l = 0;

                List.Add( EncryptBlock(mas[i], key[l] , i) );

                l++;
            }

            Out = new byte[128 * List.Count];
            int k = 0,j = 0;
            for (int i = 0; i < Out.Length; i++)
            {
                if(j  == 128)
                {
                    k++;
                    j = 0;
                }

                Out[i] = List[k][j];
                j++;
            }

            return Out;
        }
        public static string EncryptCesar(string _Message, int _key)
        {
            string OutString = "";
            for (int i = 0; i < _Message.Length; i++)
            {
                OutString += (Char)((int)_Message[i] + _key);
            }
            return OutString;
        }
    }
}

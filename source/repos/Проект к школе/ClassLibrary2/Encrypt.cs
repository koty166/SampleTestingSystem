using System;
using System.Collections.Generic;

namespace ClassLibrary2.Security
{
    static public class EncryptClass
    {
        static byte[] EncryptBlock(byte b, byte key, int seed)
        {
            byte[] mas = new byte[64];
            Random r = new Random(seed);

            for (int i = 0; i < 64; i++)
                mas[i] = (byte)r.Next(0, 256);

            mas[key] = (byte)(255 - b);
            return mas;
        }

        public static byte[] Encrypt(byte[] SerilisedData, byte[] key ,ref int DataLenght)
        {
            byte[]  Out;
            int l = 0;
            List<byte[]> List = new List<byte[]>();

            for (int i = 0; i < SerilisedData.Length; i++)
            {
                if (l == key.Length) l = 0;

                List.Add(EncryptBlock(SerilisedData[i], key[l], i));

                l++;
            }

            Out = new byte[64 * List.Count];
            int k = 0, j = 0;
            for (int i = 0; i < Out.Length; i++)
            {
                if (j == 64)
                {
                    k++;
                    j = 0;
                }

                Out[i] = List[k][j];
                j++;
            }
            DataLenght = Out.Length;
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

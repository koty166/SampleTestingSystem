using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Collections;

namespace Tools
{
    /// <summary>
    /// Раёсширяемый класс, предоставляющий различные методы для работы с данными
    /// </summary>
    public static partial class ToolsClass
    {
        

        public static object Decrypt(byte[] Message, byte[] key)
        {
            byte[] Arry = new byte[Message.Length / 64];
            byte l = 0;
            MemoryStream s = new MemoryStream();
            BinaryFormatter b = new BinaryFormatter();
            for (int i = 0; i < Arry.Length; i++)
            {
                Arry[i] = (byte)(255 - Message[i * 64 + key[l]]);
                l++;
                if (l == key.Length)
                    l = 0;
            }
            foreach (var i in Arry)
                s.WriteByte(i);

            s.Seek(0, SeekOrigin.Begin);

            return b.Deserialize(s);
        }
        public static string DecryptCesar(string _CrypedMessage, int _key)
        {
            string OutString = "";
            for (int i = 0; i < _CrypedMessage.Length; i++)
            {
                OutString += (Char)((int)_CrypedMessage[i] + _key);
            }
            return OutString;
        }

        static byte[] EncryptBlock(byte b, byte key, int seed)
        {
            byte[] mas = new byte[64];
            Random r = new Random(seed);

            for (int i = 0; i < 64; i++)
                mas[i] = (byte)r.Next(0, 256);

            mas[key] = (byte)(255 - b);
            return mas;
        }

        public static byte[] Encrypt(byte[] SerilisedData, byte[] key, ref int DataLenght)
        {
            byte[] Out;
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

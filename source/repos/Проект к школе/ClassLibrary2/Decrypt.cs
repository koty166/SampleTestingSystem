using System;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace ClassLibrary2.Security
{
   public class DecryptClass
    {
        public static object Decrypt(byte[] Message, byte[] key)
        {
            byte[] Arry = new byte[Message.Length / 128];
            byte l = 0;
            MemoryStream s = new MemoryStream();
            BinaryFormatter b = new BinaryFormatter();
            for (int i = 0; i < Arry.Length; i++)
            {
                Arry[i] = Message[i * 128 + key[l]];
                l++;
                if (l == key.Length)
                    l = 0;
            }
            foreach (var i in Arry)
                s.WriteByte(i);

            s.Seek(0,SeekOrigin.Begin);

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
    }

}

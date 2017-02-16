using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
namespace ktf.Lib
{
    [DebuggerStepThrough]
    internal static class Base64
    {
       public  class Object64
        {
            /// <summary>
            /// Objects to string.
            /// </summary>
            /// <param name="obj">The object.</param>
            /// <returns></returns>
            public string ObjectToString(object obj)
            {

                using (MemoryStream ms = new MemoryStream())
                {
                    new BinaryFormatter().Serialize(ms, obj);
                    return Convert.ToBase64String(ms.ToArray());
                }
            }


            /// <summary>
            /// Strings to object.
            /// </summary>
            /// <param name="base64String">The base64 string.</param>
            /// <returns></returns>
            public object StringToObject(string base64String)
            {
                
                byte[] bytes = Convert.FromBase64String(base64String);
                using (MemoryStream ms = new MemoryStream(bytes, 0, bytes.Length))
                {
                    ms.Write(bytes, 0, bytes.Length);
                    ms.Position = 0;
                    return new BinaryFormatter().Deserialize(ms);
                }
            }

        }

       /// <summary>
       /// Fileto64srings the specified filename.
       /// </summary>
       /// <param name="filename">The filename.</param>
       /// <returns></returns>
        public static string Fileto64sring(string filename)
        {
            string str = ""; ;
            try
            {
                MemoryStream memorystream = new MemoryStream();

                memorystream = read(filename);
                byte[] bitmapbytes = memorystream.GetBuffer();
                str = Convert.ToBase64String(bitmapbytes, Base64FormattingOptions.None);
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message);
            }
            return str;

        }

        static MemoryStream read(string filename)
        {
            using (MemoryStream ms = new MemoryStream())
            using (FileStream file = new FileStream(filename,
            FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[file.Length];
                file.Read(bytes, 0, (int)file.Length);
                ms.Write(bytes, 0, (int)file.Length);
                return ms;
            }


        }
        static void write(MemoryStream ms, string filename)
        {
            using (FileStream file = new FileStream(filename,
  FileMode.Create, System.IO.FileAccess.Write))
            {
                byte[] bytes = new byte[ms.Length];
                ms.Read(bytes, 0, (int)ms.Length);
                file.Write(bytes, 0, bytes.Length);
                ms.Close();
            }



        }



        /// <summary>
        /// B64s the stringtofile.
        /// </summary>
        /// <param name="StrIng">The string ing.</param>
        /// <param name="filename">The filename.</param>
        public static void B64Stringtofile(string StrIng, string filename)
        {

            try
            {

                byte[] bitmapbytes = Convert.FromBase64String(StrIng);
                using (MemoryStream memorystream = new MemoryStream(bitmapbytes))
                {
                    write(memorystream, filename);
                }
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message);
            }

        }


        /// <summary>
        /// Base64s the encode.
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <returns></returns>
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes =
          System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String
          (plainTextBytes);
        }

        /// <summary>
        /// Base64s the decode.
        /// </summary>
        /// <param name="base64EncodedData">The base64 encoded data.</param>
        /// <returns></returns>
        public static string Base64Decode(string
        base64EncodedData)
        {
            var base64EncodedBytes =
          System.Convert.FromBase64String
          (base64EncodedData);
            return System.Text.Encoding.UTF8.GetString
          (base64EncodedBytes);
        }






    }
}

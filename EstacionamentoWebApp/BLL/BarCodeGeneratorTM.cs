using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EstacionamentoWebApp.BLL

{
    public class BarCodeGeneratorTM
    {

        public string generateCode()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[11];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }

        public byte[] turnImageToByteArray(System.Drawing.Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            return ms.ToArray();
        }

        public string turByteEmString64TM(byte[] aux)
        {
            string susanoo = Convert.ToBase64String(aux);
            return susanoo;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamentoWebApp.Controllers
{
    public class BarCodeGeneratorTM
    {

        public string generateCode()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[11];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
        
    }
}
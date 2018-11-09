using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    class StringGenerator : IValueGenerator
    {
        public object Generate()
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rand = new Random();
            return new string(chars.Select(c => chars[rand.Next(chars.Length)]).Take(rand.Next(1, 1024)).ToArray());
            //string resultStr = String.Empty;
            //int ammountOfSymb = rand.Next(1, 20);
            //for (int i = 0; i < ammountOfSymb; i++)
            //{
            //    resultStr += chars[rand.Next(chars.Length)];
            //}
            //return resultStr;
        }
    }
}

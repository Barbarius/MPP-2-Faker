using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    class StringGenerator : IValueGenerator
    {
        public object Generate()
        {
            var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            Random rand = new Random();
            return new string(chars.Select(c => chars[rand.Next(chars.Length)]).Take(rand.Next(1, 1024)).ToArray());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    class CharGenerator : IValueGenerator
    {
        public object Generate()
        {
            Random rand = new Random();
            return Convert.ToChar(Convert.ToInt32(Math.Floor(26 * rand.NextDouble() + 65)));
        }
    }
}

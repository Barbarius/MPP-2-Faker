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
            return Convert.ToChar(Convert.ToInt32(Math.Floor(26 * Randomizer.RandomValue.NextDouble() + 65)));
        }
    }
}

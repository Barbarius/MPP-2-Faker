using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    class BoolGenerator : IValueGenerator
    {
        public object Generate()
        {
            return Randomizer.randomValue.Next(100) < 50;
        }
    }
}

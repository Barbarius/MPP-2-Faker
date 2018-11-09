using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    class ShortGenerator : IValueGenerator
    {
        public object Generate()
        {
            return (short)Randomizer.randomValue.Next();
        }
    }
}

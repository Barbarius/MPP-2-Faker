using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    class SByteGenerator : IValueGenerator
    {
        public object Generate()
        {
            return (sbyte)Randomizer.randomValue.Next();
        }
    }
}

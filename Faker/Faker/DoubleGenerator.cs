﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    class DoubleGenerator : IValueGenerator
    {
        public object Generate()
        {
            return Randomizer.RandomValue.NextDouble();
        }
    }
}

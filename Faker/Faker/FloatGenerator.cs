﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    class FloatGenerator : IValueGenerator
    {
        public object Generate()
        {
            Random rand = new Random();
            return (float)rand.NextDouble();
        }
    }
}

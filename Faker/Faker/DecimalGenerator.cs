﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    class DecimalGenerator : IValueGenerator
    {
        public object Generate()
        {
            Random rand = new Random();
            return (decimal)rand.Next();
        }
    }
}

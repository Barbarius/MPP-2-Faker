﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    class LongGenerator : IValueGenerator
    {
        public object Generate()
        {
            Random rand = new Random();
            return (long)rand.Next();
        }
    }
}
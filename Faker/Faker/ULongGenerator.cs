﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    class ULongGenerator : IValueGenerator
    {
        public object Generate()
        {
            Random rand = new Random();
            return (ulong)rand.Next();
        }
    }
}
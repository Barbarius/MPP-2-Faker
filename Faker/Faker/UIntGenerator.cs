﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    class UIntGenerator : IValueGenerator
    {
        public object Generate()
        {
            Random rand = new Random();
            return (uint)rand.Next();
        }
    }
}
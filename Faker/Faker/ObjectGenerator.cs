﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    class ObjectGenerator : IValueGenerator
    {
        public object Generate()
        {
            return new object();
        }
    }
}
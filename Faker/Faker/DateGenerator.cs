﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    class DateGenerator : IValueGenerator
    {
        public object Generate()
        {
            return DateTime.Now;
        }
    }
}

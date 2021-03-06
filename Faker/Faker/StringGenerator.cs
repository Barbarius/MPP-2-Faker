﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    class StringGenerator : IValueGenerator
    {
        public object Generate()
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rand = new Random();
            return new string(chars.Select(c => chars[Randomizer.RandomValue.Next(chars.Length)]).Take(Randomizer.RandomValue.Next(1, 1024)).ToArray());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakerLib;

namespace GeneratorPlugins
{
    public class IntPluginGenerator : IPlugin
    {
        public Type GeneratedType
        { get; protected set; }

        public object Generate()
        {
            return Randomizer.RandomValue.Next();
        }

        public IntPluginGenerator()
        {
            GeneratedType = typeof(int);
        }
    }
}

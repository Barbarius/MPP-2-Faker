using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faker;

namespace GeneratorPlugins
{
    public class IntPluginGenerator : IPlugin
    {
        public Type GeneratedType
        { get; protected set; }

        public object Generate()
        {
            Random rand = new Random();
            return rand.Next();
        }

        public IntPluginGenerator()
        {
            GeneratedType = typeof(int);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faker;

namespace GeneratorPlugins
{
    public class ObjectPluginGenerator : IPlugin
    {
        public Type GeneratedType
        { get; protected set; }

        public object Generate()
        {
            return new object();
        }

        public ObjectPluginGenerator()
        {
            GeneratedType = typeof(object);
        }
    }
}

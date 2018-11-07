using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    class ListGenerator : IGenericGenerator
    {
        protected readonly ByteGenerator byteGenerator;
        protected IDictionary<Type, IValueGenerator> baseTypesGenerators;

        public object Generate(Type baseType)
        {
            IList result = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(baseType));

            if (baseTypesGenerators.TryGetValue(baseType, out IValueGenerator baseTypeGenerator))
            {
                byte listSize = (byte)byteGenerator.Generate();

                for (int i = 0; i < listSize; i++)
                {
                    result.Add(baseTypeGenerator.Generate());
                }
            }
            return result;
        }

        public ListGenerator(IDictionary<Type, IValueGenerator> baseTypesGenerators)
        {
            this.baseTypesGenerators = baseTypesGenerators;
            byteGenerator = new ByteGenerator();
        }
    }
}

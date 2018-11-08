using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Faker
{
    class Faker : IFaker
    {
        protected Dictionary<Type, IValueGenerator> baseTypesGenerators;
        ListGenerator listGenerator;
        private static Assembly asm;

        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }

        public object Create(Type t)
        {
            // получение параметров конструктора
            ConstructorInfo[] constructorInfo = t.GetConstructors();
            ParameterInfo[] parameterInfo;
            ConstructorInfo parametrizedConstructor = null;

            // выбираем конструктор с наибольшим числом параметров
            int maxConstructorFieldsCount = 0;
            foreach (ConstructorInfo info in constructorInfo)
            {
                parameterInfo = info.GetParameters();
                if (parameterInfo.Length > maxConstructorFieldsCount)
                {
                    maxConstructorFieldsCount = parameterInfo.Length;
                    parametrizedConstructor = info;
                }
            }

            // создание объекта
            object obj;
            if (parametrizedConstructor != null)
            {
                // по конструктору
                obj = CreateByConstructor(t, parametrizedConstructor);
            }
            else
            {
                // по public полям
                obj = CreateByPublicFields(t);
            }

            return obj;
        }

        private object CreateByConstructor(Type t, ConstructorInfo constructor)
        {
            // создаём объект по конструктору
            object[] tmp = new object[constructor.GetParameters().Length];
            int i = 0;

            // заполняем параметры
            foreach (ParameterInfo pi in constructor.GetParameters())
            {
                tmp[i] = GenerateValue(pi.ParameterType);
                i++;
            }

            return constructor.Invoke(tmp);
        }

        private object CreateByPublicFields(Type t)
        {
            //NEED TO ADD CHECH ON ONLY GET-PROPERTIES
            object tmp = Activator.CreateInstance(t);

            FieldInfo[] fieldInfo = t.GetFields(BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo[] propertyInfo = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // заполняем поля
            foreach (FieldInfo info in fieldInfo)
                info.SetValue(tmp, GenerateValue(info.FieldType));

            // заполняем свойства
            foreach (PropertyInfo info in propertyInfo)
                info.SetValue(tmp, GenerateValue(info.PropertyType));

            return tmp;
        }

        protected object GenerateValue(Type type)
        {
            object generatedObj = null;

            // создаём значение в соответствии с типом
            if (baseTypesGenerators.TryGetValue(type, out IValueGenerator baseTypeGenerator))
            {
                generatedObj = baseTypeGenerator.Generate();
            }
            else if (type.IsGenericType)    // list
            {
                generatedObj = listGenerator.Generate(type.GenericTypeArguments[0]);
            }
            /*else if (type.IsArray)
            {
                generatedObj = arrayGenerator.Generate(type.GetElementType());  
            }*/
            else if (type.IsClass && !type.IsGenericType && !type.IsArray && !type.IsPointer && !type.IsAbstract/* && !generatedTypes.Contains(type)*/)
            {
                generatedObj = Create(type);

                /*int maxConstructorFieldsCount = 0, curConstructorFieldsCount;
                ConstructorInfo constructorToUse = null;

                foreach (ConstructorInfo constructor in type.GetConstructors())
                {
                    curConstructorFieldsCount = constructor.GetParameters().Length;
                    if (curConstructorFieldsCount > maxConstructorFieldsCount)
                    {
                        maxConstructorFieldsCount = curConstructorFieldsCount;
                        constructorToUse = constructor;
                    }
                }

                generatedTypes.Push(type);
                if (constructorToUse == null)
                {
                    generatedObj = CreateByProperties(type);
                }
                else
                {
                    generatedObj = CreateByConstructor(type, constructorToUse);
                }
                generatedTypes.Pop();*/
            }
            else if (type.IsValueType)
            {
                generatedObj = Activator.CreateInstance(type);
            }
            else
            {
                generatedObj = null;
            }

            return generatedObj;
        }

        public Faker()
        {
            asm = Assembly.LoadFrom("C:\\Users\\Sergei\\Documents\\СПП\\MPP-2-Faker\\Faker\\GeneratorPlugins\\bin\\Debug\\GeneratorPlugins.dll");

            // base types
            baseTypesGenerators = new Dictionary<Type, IValueGenerator>();

            //baseTypesGenerators.Add(typeof(object), new ObjectGenerator());
            baseTypesGenerators.Add(typeof(char), new CharGenerator());
            baseTypesGenerators.Add(typeof(bool), new BoolGenerator());
            baseTypesGenerators.Add(typeof(byte), new ByteGenerator());
            baseTypesGenerators.Add(typeof(sbyte), new SByteGenerator());
            //baseTypesGenerators.Add(typeof(int), new IntGenerator());
            baseTypesGenerators.Add(typeof(uint), new UIntGenerator());
            baseTypesGenerators.Add(typeof(short), new ShortGenerator());
            baseTypesGenerators.Add(typeof(ushort), new UShortGenerator());
            baseTypesGenerators.Add(typeof(long), new LongGenerator());
            baseTypesGenerators.Add(typeof(ulong), new ULongGenerator());
            baseTypesGenerators.Add(typeof(decimal), new DecimalGenerator());
            baseTypesGenerators.Add(typeof(float), new FloatGenerator());
            baseTypesGenerators.Add(typeof(double), new DoubleGenerator());
            baseTypesGenerators.Add(typeof(DateTime), new DateGenerator());
            baseTypesGenerators.Add(typeof(string), new StringGenerator());

            // plugins
            var types = asm.GetTypes().Where(t => t.GetInterfaces().Where(i => i == typeof(IPlugin)).Any());

            foreach (var type in types)
            {
                var plugin = asm.CreateInstance(type.FullName) as IPlugin;
                if (!baseTypesGenerators.ContainsKey(plugin.GeneratedType))
                    baseTypesGenerators.Add(plugin.GeneratedType, plugin);
            }

            // list - genric type
            listGenerator = new ListGenerator(baseTypesGenerators);
        }
    }
}

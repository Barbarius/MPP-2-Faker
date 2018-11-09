using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FakerLib
{
    public class Faker : IFaker
    {
        protected Dictionary<Type, IValueGenerator> baseTypesGenerators;
        ListGenerator listGenerator;
        private static Assembly asm;
        protected List<Type> generatedTypes;

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

            // проверяем конструктор на приватность
            //bool isPrivate = false;
            if (constructorInfo.Length == 0)
            {
                //isPrivate = true;
                return null;
            }

            // выбираем конструктор с наибольшим числом параметров
            int maxConstructorFieldsCount = 0;
            //constructorInfo.Max(x => x.GetParameters().Length)
            foreach (ConstructorInfo info in constructorInfo)
            {
                parameterInfo = info.GetParameters();
                if (parameterInfo.Length > maxConstructorFieldsCount)
                {
                    maxConstructorFieldsCount = parameterInfo.Length;
                    parametrizedConstructor = info;
                }
                //else if (parameterInfo.Length == 0 && maxConstructorFieldsCount == 0)
                //{
                //    isPrivate = info.IsPrivate;
                //}
            }

            // создание объекта
            object obj;
            if (parametrizedConstructor != null)
            {
                // по конструктору
                obj = CreateByConstructor(t, parametrizedConstructor);
            }
            //else if (isPrivate)
            //{
            //    return null;
            //}
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
            object tmp = Activator.CreateInstance(t); ;

            FieldInfo[] fieldInfo = t.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            PropertyInfo[] propertyInfo = t.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            // заполняем поля
            foreach (FieldInfo info in fieldInfo)
                info.SetValue(tmp, GenerateValue(info.FieldType));

            // заполняем свойства
            foreach (PropertyInfo info in propertyInfo)
            {
                if (info.CanWrite)
                    info.SetValue(tmp, GenerateValue(info.PropertyType));
            }

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
            else if (type.IsClass && !type.IsGenericType && !type.IsArray && !type.IsPointer && !type.IsAbstract && !generatedTypes.Contains(type))
            {
                generatedTypes.Add(type);

                generatedObj = Create(type);

                generatedTypes.RemoveAt(generatedTypes.Count - 1);
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
            generatedTypes = new List<Type>();

            asm = Assembly.LoadFrom("Plugins\\GeneratorPlugins.dll");

            // базовые типы
            baseTypesGenerators = new Dictionary<Type, IValueGenerator>
            {
                { typeof(object), new ObjectGenerator() },
                { typeof(char), new CharGenerator() },
                { typeof(bool), new BoolGenerator() },
                { typeof(byte), new ByteGenerator() },
                { typeof(sbyte), new SByteGenerator() },
                { typeof(int), new IntGenerator() },
                { typeof(uint), new UIntGenerator() },
                { typeof(short), new ShortGenerator() },
                { typeof(ushort), new UShortGenerator() },
                { typeof(long), new LongGenerator() },
                { typeof(ulong), new ULongGenerator() },
                { typeof(decimal), new DecimalGenerator() },
                { typeof(float), new FloatGenerator() },
                { typeof(double), new DoubleGenerator() },
                { typeof(DateTime), new DateGenerator() },
                { typeof(string), new StringGenerator() }
            };

            // плагины
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

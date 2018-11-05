using System;
using System.Reflection;

namespace Faker
{
    class Faker : IFaker
    {
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
            //if (baseTypesGenerators.TryGetValue(type, out IBaseTypeGenerator baseTypeGenerator))
            if (IsBaseType(type))
            {
                generatedObj = baseTypeGenerator.Generate();
            }
            else if (type.IsGenericType)
            {
                generatedObj = genericTypeGenerator.Generate(type.GenericTypeArguments[0]);
            }
            else if (type.IsArray)
            {
                generatedObj = arrayGenerator.Generate(type.GetElementType());  
            }
            else if (type.IsClass && !type.IsGenericType && !type.IsArray && !type.IsPointer && !type.IsAbstract && !generatedTypes.Contains(type))
            {
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

        private bool IsBaseType(Type type)
        {
            return true;
        }
    }
}

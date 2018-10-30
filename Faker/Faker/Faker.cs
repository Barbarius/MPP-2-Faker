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
            //lets find parametrized constructor
            ConstructorInfo[] constructorInfo = t.GetConstructors();
            ParameterInfo[] parameterInfo;
            ConstructorInfo parametrizedConstructor = null;
            foreach (ConstructorInfo info in constructorInfo)
            {
                parameterInfo = info.GetParameters();
                if (parameterInfo.Length > 0)
                    parametrizedConstructor = info;
            }

            object obj;
            if (parametrizedConstructor != null)
            {
                //create by parametrized constructor
                obj = CreateByConstructor(t, parametrizedConstructor);
            }
            else
            {
                //create by public fields/properties 
                obj = CreateByPublicFields(t);
            }

            return obj;
        }

        private object CreateByConstructor(Type t, ConstructorInfo info)
        {
            //temp object for infoking constructor
            object[] tmp = new object[info.GetParameters().Length];
            int i = 0;

            //fill in object
            foreach (ParameterInfo pi in info.GetParameters())
            {
                tmp[i] = FieldValueGenerator.GenerateValue(pi.ParameterType);
                i++;
            }

            return info.Invoke(tmp);
        }

        private object CreateByPublicFields(Type t)
        {
            //NEED TO ADD CHECH ON ONLY GET-PROPERTIES
            object tmp = Activator.CreateInstance(t);

            //get public fields
            FieldInfo[] fieldInfo = t.GetFields(BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo[] propertyInfo = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            //setting values to public fields
            foreach (FieldInfo info in fieldInfo)
                info.SetValue(tmp, FieldValueGenerator.GenerateValue(info.FieldType));

            foreach (PropertyInfo info in propertyInfo)
                info.SetValue(tmp, FieldValueGenerator.GenerateValue(info.PropertyType));

            return tmp;
        }
    }
}

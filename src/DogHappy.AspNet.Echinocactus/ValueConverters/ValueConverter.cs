using System;
using System.Collections;

namespace DogHappy.AspNet.Echinocactus.ValueConverters
{
    /// <summary>
    /// 
    /// </summary>
    public static class ValueConverter
    {
        private static IValueConverter GetConverter(Type type)
        {
            IValueConverter converter = null;
            switch (type)
            {
                case Type _ when type == typeof(string):
                    converter = new StringConverter();
                    break;
                case Type _ when type == typeof(short):
                    converter = new Int16Converter();
                    break;
                case Type _ when type == typeof(int):
                    converter = new Int32Converter();
                    break;
                case Type _ when type == typeof(long):
                    converter = new Int64Converter();
                    break;
                case Type _ when type == typeof(char):
                    converter = new CharConverter();
                    break;
                case Type _ when type == typeof(Guid):
                    converter = new GuidConverter();
                    break;
                case Type _ when type == typeof(DateTime):
                    converter = new DateTimeConverter();
                    break;
                case Type _ when type == typeof(DateTimeOffset):
                    converter = new DateTimeOffsetConverter();
                    break;
                case Type _ when type == typeof(float):
                    converter = new FloatConverter();
                    break;
                case Type _ when type == typeof(double):
                    converter = new DoubleConverter();
                    break;
                case Type _ when type == typeof(decimal):
                    converter = new DecimalConverter();
                    break;
            }
            return converter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T As<T>(object value)
        {
            Type type = typeof(T);
            Type underlyingType = Nullable.GetUnderlyingType(type);
            if (type.IsArray)
            {
                Type elementType = type.GetElementType();
                IValueConverter converter = GetConverter(elementType);
                if (converter != null)
                {
                    string[] items = value.ToString().Split(',');
                    Array array = Array.CreateInstance(elementType, items.Length);
                    for (int i = 0; i < items.Length; i++)
                    {
                        var element = converter.Convert(items[i]);
                        array.SetValue(element, i);
                    }
                    return (T)(object)array;
                }
            }
            else if (type != typeof(string) && type.GetInterface(nameof(IEnumerable)) != null)
            {
                //Type elementType = type.GenericTypeArguments[0];
                //IValueConverter converter = GetConverter(elementType);
                //if (converter != null)
                //{
                //    string[] items = value.ToString().Split(',');
                //    var collection = Activator.CreateInstance<T>();
                //    Type collectionType = collection.GetType();
                //    var method = collectionType.GetMethod("Add");
                //    if (method == null)
                //    {
                //        throw new TypeInitializationException(collectionType.FullName, new Exception("There is no Add method in the type definition."));
                //    }
                //    foreach (var item in items)
                //    {
                //        var element = converter.Convert(item);
                //        method.Invoke(collection, new[] { element });
                //    }
                //    return (T)(object)collection;
                //}
                throw new ArgumentException($"Unable to get the data of the generic class, please try using: {type.GenericTypeArguments[0].FullName}[]");
            }
            else
            {
                IValueConverter converter = underlyingType == null ? GetConverter(type) : GetConverter(underlyingType);
                if (converter != null)
                {
                    return (T)converter.Convert(value);
                }
            }
            return default;
        }
    }
}

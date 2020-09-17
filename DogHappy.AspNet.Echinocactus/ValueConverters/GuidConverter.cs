using System;

namespace DogHappy.AspNet.Echinocactus.ValueConverters
{
    class GuidConverter : IValueConverter
    {
        public object Convert(object value)
        {
            Type valueType = value.GetType();
            if (valueType == typeof(string) && value != null)
            {
                return Guid.Parse(value.ToString());
            }
            return null;
        }
    }
}

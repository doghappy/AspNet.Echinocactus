using System;

namespace DogHappy.AspNet.Echinocactus.ValueConverters
{
    class DateTimeOffsetConverter : IValueConverter
    {
        public object Convert(object value)
        {
            if (value == null)
            {
                return default(DateTimeOffset);
            }
            return DateTimeOffset.Parse(value.ToString());
        }
    }
}

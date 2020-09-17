using System;

namespace DogHappy.AspNet.Echinocactus.ValueConverters
{
    class DateTimeConverter : IValueConverter
    {
        public object Convert(object value)
        {
            if (value == null)
            {
                return default(DateTime);
            }
            return DateTime.Parse(value.ToString());
        }
    }
}

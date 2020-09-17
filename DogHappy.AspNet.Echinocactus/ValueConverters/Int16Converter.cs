namespace DogHappy.AspNet.Echinocactus.ValueConverters
{
    class Int16Converter : IValueConverter
    {
        public object Convert(object value)
        {
            if (value == null)
            {
                return default(short);
            }
            short.TryParse(value.ToString(), out short result);
            return result;
        }
    }
}

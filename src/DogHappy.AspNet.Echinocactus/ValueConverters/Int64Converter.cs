namespace DogHappy.AspNet.Echinocactus.ValueConverters
{
    class Int64Converter : IValueConverter
    {
        public object Convert(object value)
        {
            if (value == null)
            {
                return default(long);
            }
            long.TryParse(value.ToString(), out long result);
            return result;
        }
    }
}

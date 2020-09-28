namespace DogHappy.AspNet.Echinocactus.ValueConverters
{
    class Int32Converter : IValueConverter
    {
        public object Convert(object value)
        {
            if (value == null)
            {
                return default(int);
            }
            int.TryParse(value.ToString(), out int result);
            return result;
        }
    }
}

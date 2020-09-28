namespace DogHappy.AspNet.Echinocactus.ValueConverters
{
    class DecimalConverter : IValueConverter
    {
        public object Convert(object value)
        {
            if (value == null)
            {
                return default(decimal);
            }
            decimal.TryParse(value.ToString(), out decimal result);
            return result;
        }
    }
}

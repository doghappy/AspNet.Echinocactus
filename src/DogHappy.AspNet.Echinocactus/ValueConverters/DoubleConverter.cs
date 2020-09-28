namespace DogHappy.AspNet.Echinocactus.ValueConverters
{
    class DoubleConverter : IValueConverter
    {
        public object Convert(object value)
        {
            if (value == null)
            {
                return default(double);
            }
            double.TryParse(value.ToString(), out double result);
            return result;
        }
    }
}

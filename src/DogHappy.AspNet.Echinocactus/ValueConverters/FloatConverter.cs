namespace DogHappy.AspNet.Echinocactus.ValueConverters
{
    class FloatConverter : IValueConverter
    {
        public object Convert(object value)
        {
            if (value == null)
            {
                return default(float);
            }
            float.TryParse(value.ToString(), out float result);
            return result;
        }
    }
}

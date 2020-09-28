namespace DogHappy.AspNet.Echinocactus.ValueConverters
{
    class StringConverter : IValueConverter
    {
        public object Convert(object value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            return value.ToString();
        }
    }
}

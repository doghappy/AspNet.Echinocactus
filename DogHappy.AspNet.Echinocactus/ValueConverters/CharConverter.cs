namespace DogHappy.AspNet.Echinocactus.ValueConverters
{
    class CharConverter : IValueConverter
    {
        public object Convert(object value)
        {
            if (value == null)
            {
                return default(char);
            }
            string str = value.ToString();
            return str[0];
        }
    }
}

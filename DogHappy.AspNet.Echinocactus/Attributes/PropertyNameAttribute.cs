using System;

namespace DogHappy.AspNet.Echinocactus.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyNameAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public PropertyNameAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Property name
        /// </summary>
        public string Name { get; }
    }
}

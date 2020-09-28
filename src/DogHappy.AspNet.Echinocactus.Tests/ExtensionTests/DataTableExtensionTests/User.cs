using DogHappy.AspNet.Echinocactus.Attributes;

namespace DogHappy.AspNet.Echinocactus.Tests.ExtensionTests.DataTableExtensionTests
{
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        [PropertyName("Gender")]
        public int? Sex { get; set; }

        public bool IsDeleted { get; set; }
    }
}

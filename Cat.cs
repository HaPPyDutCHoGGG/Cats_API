using System.ComponentModel.DataAnnotations;

namespace Cats_API
{
    public class Cat
    {
        public int id { get; set; }
        [Key]
        public string name { get; set; }
        public int age { get; set; }
        public string breed { get; set; }
        public string gender { get; set; }
        public string color { get; set; }
    }
}

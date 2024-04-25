using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public class Person
    {
        public int PersonID { get; set; }

        public string FirstName { get; set; } = string.Empty;

        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;
    }
}

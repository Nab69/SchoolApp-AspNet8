using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public class Teacher : Person
    {
        [Required]
        public string Discipline { get; set; } = string.Empty;

        [Range(1000, 3000)]
        public int Salary { get; set; }
    }
}

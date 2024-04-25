namespace DomainModel
{
    public class Teacher : Person
    {
        public string Discipline { get; set; } = string.Empty;

        public int Salary { get; set; }
    }
}

namespace DomainModel
{
    public class Classroom
    {
        // scalar properties
        public int ClassroomID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Floor { get; set; }
        public string Corridor { get; set; } = string.Empty;

        // navigation properties
        public ICollection<Student>? Students { get; set; }
        public Teacher? Teacher { get; set; }
    }
}

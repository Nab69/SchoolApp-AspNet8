namespace DomainModel
{
    public class Classroom
    {
        public int ClassroomID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Floor { get; set; }
        public string Corridor { get; set; } = string.Empty;
    }
}

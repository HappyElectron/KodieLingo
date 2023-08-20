namespace KodieLingo.Model
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Relational mapping:
        // Many-to-many ef models require a 'join' class to track foreign keys,
        // which both entities reference. EF is doing such automatically here.
        public ICollection<Course> Course { get; set; } = new List<Course>();
    }
}
    
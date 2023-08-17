namespace KodieLingo.Model
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Topic> Topic { get; set; } = new List<Topic>();

        // Foreign Keys
        public Course Course { get; set; } = null!;
        public int CourseId { get; set; }
    }
}

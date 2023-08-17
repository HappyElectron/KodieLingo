namespace KodieLingo.Model
{
    // The Course class
    //
    // Along with it's child components (sections, topics, questions, lessons)
    // these make up the entirety of the courses system
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Topical tags: many-to-many
        // public ICollection<Tag> Tag { get; set; } = new List<Tag>();

        // Relational mapping to sections: this contains all course content.
        public ICollection<Section> Section { get; set; } = new List<Section>();
    }
}

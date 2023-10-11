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

        // Many-to-many ef models require a 'join' class to track foreign keys,
        // which both entities reference. EF is doing such automatically here.
        public ICollection<Tag> Tag { get; set; } = new List<Tag>();

        // Many users have many courses
        public ICollection<User> User { get; set; } = new List<User>();

        // Prerequisites: Many courses have many prerequisites. Similar to friends, this is shit.
        public ICollection<Course> Prerequisite { get; set; } = new List<Course>();
        public ICollection<Course> PrerequisiteParent { get; set; } = new List<Course>();

        public ICollection<CourseProgressTracker> CourseProgressTrackers { get; set; } = new List<CourseProgressTracker>();
    }
}

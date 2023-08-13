namespace KodieLingo.Model
{
    // The Course class
    //
    // Along with it's child components (sections, topics, questions, lessons)
    // these make up the entirety of the courses system.
    // 
    // When a user needs to access given courses, they will send a request to the server
    // with the course id(s) they require, and will be returned the course objects
    //
    // Presently, all child objects are stored within the course, without their own tables
    // This may need to change, but we can largely ignore this for now, as we set up the user system.
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Storing the actual objects, as they have no separate table.
        public List<Section>? Sections { get; set; }
        // Topical tags
        public List<string>? Tags { get; set; }

        // References to other courses. 
        // name : id structure, so that the name can be displayed and the id used for a redirect.
        public Dictionary<string, int>? Prerequisites { get; set; }
    }
}

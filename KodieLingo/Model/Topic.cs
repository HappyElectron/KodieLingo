namespace KodieLingo.Model
{
    public class Topic
    {
        // Topics 
        public int Id { get; set; }
        public string Name { get; set; }

        // Should consider making the guidebook it's own component:
        // Would allow for easier formatting. Bit much work for now tho.
        public string Guidebook { get; set; }

        public List<Question>? Questions { get; set; }
        public List<Lesson>? Lessons { get; set; }
    }
}

namespace KodieLingo.Model
{
    public class Topic
    {
        // Topics, within sections
        public int Id { get; set; }
        public string Name { get; set; }

        // Should consider making the guidebook it's own component:
        // Would allow for easier formatting. Bit much work for now tho.
        public string Guidebook { get; set; }

        public ICollection<Question> Question { get; set; } = new List<Question>();
        
        public ICollection<Lesson> Lesson { get; set; } = new List<Lesson>();

        // Foreign keys
        public Section Section { get; set; } = null!;
        public int SectionId { get; set; }
    }
}

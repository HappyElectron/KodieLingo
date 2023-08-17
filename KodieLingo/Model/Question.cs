namespace KodieLingo.Model
{
    public class Question
    {
        // A question in a lesson.
        // Questions/Answers will be modelled by a one-to-many relationship (link below).
        // https://learn.microsoft.com/en-us/ef/core/modeling/relationships/one-to-many
        // Questions will be accessable from other objects by a many-to-many relationship.
        // https://learn.microsoft.com/en-us/ef/core/modeling/relationships/many-to-many
        public int Id { get; set; }
        public string QuestionString { get; set; }

        public ICollection<Answer> Answers { get; set; } = new List<Answer>();

        // Foreign Keys
        public Topic Topic { get; set; } = null!;
        public int TopicId { get; set; }
    }
}

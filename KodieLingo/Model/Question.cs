namespace KodieLingo.Model
{
    public class Question
    {
        // A question in a lesson.
        // The questions will be stored as a set, and topics will track a set of
        // question IDs, which will be used to generate a given lesson.
        public int Id { get; set; }
        public string QuestionString { get; set; }

        // Trying to reference a dynamic list of objects from a DB item.
        public List<Answer> Answers { get; set; } = new();
    }
}

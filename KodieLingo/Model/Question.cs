namespace KodieLingo.Model
{
    public class Question
    {
        // A question in a lesson.
        // To be stored within a topic, and accessed by an active lesson page - not the lesson DB object
        public int Id { get; set; }
        public string QuestionString { get; set; }

        // Identifying integer : string question
        public List<int>? ValidAnswers { get; set; }
        public Dictionary<int,string>? Answers { get; set; }
    }
}

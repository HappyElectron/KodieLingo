namespace KodieLingo.Model
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerString { get; set; }
        public bool IsValid { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; } = null!;
    }
}

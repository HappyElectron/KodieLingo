using KodieLingo.Model;
using Microsoft.EntityFrameworkCore;

namespace KodieLingo.Data
{
    // This class is a level of separation from the modelbuilder; it exists for readability/cleanliness.
    public static class ModelBuilderExtensions
    {
        // Seeding the DB via the HasData method will only populate rows if they are empty
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Questions/Answers are in a one-to-many relationship. This is described further in the model.
            modelBuilder.Entity<Question>().
                HasData(new Question()
                {
                    Id = 1,
                    QuestionString = "Why"
                });

            modelBuilder.Entity<Answer>().
                HasData(new Answer()
                {
                    Id = 1,
                    AnswerString = "Ned's fault",
                    IsValid = false,
                    QuestionId = 1
                },
                new Answer()
                {
                    Id = 2,
                    AnswerString = "Aiden's fault",
                    IsValid = true,
                    QuestionId = 1
                });
        }
    }
}

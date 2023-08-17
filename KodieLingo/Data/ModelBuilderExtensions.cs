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
            modelBuilder.Entity<Course>()
                .HasData(new Course()
                {
                    Id = 1,
                    Name = "C#",
                    Description = "A super fun language to code in with your best buds ever"
                });

            modelBuilder.Entity<Section>()
                .HasData(new Section()
                {
                    Id = 1,
                    Name = "Procedural Programming",
                    Description = "Learning how computers interpret commands",
                    CourseId = 1
                });
            
            // Topics/Questions are a one-to-many relationship.
            modelBuilder.Entity<Topic>()
                .HasData(new Topic()
                {
                    Id = 1,
                    Name = "If Statements",
                    Guidebook = "Don't be an idiot, type the words.",
                    SectionId = 1
                });
            // Questions/Answers are in a one-to-many relationship. This is described further in the model.
            modelBuilder.Entity<Question>().
                HasData(new Question()
                {
                    Id = 1,
                    QuestionString = "Why",
                    TopicId = 1,
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

            modelBuilder.Entity<Lesson>()
                .HasData(new Lesson()
                {
                    Id = 1,
                    Difficulty = 5,
                    IsTest = false,
                    TopicId = 1,
                });
        }
    }
}

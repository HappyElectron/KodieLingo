using KodieLingo.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

/* The model Entity Framework uses to construct a database
 * Contains a 'Set' of users; this holds all user data across several sqlite tables.
 */
namespace KodieLingo.Data
{
    public class DatabaseContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbSet<User> Users { get; set; }

        // Courses require modification before adding to the db structure.
        //public DbSet<Course> Courses { get; set; }

        // A set of questions: to be referenced and accessed by topics/lessons
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public DbSet<Topic> Topic { get; set; }
        // An interface required to connect to the database
        public DatabaseContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Connect to sqlite database on start
        // May need to change this, check hosting availablities
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(Configuration.GetConnectionString("DB"));
        }

        // When creating Entity Framework db, seed with a base user.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User table initialisation
            modelBuilder.Entity<User>()
                .ToTable("User");

            modelBuilder.Entity<User>()
                .HasData(new User() {Id = 1, 
                    Username = "Aiden's Mom", 
                    Email = "FrenchMommy@dosomeworkaiden.punk", 
                    Password = "Who cares if it's public and unsanitized"} );

            // Question/Answer mapping: one question, many answers
            modelBuilder.Entity<Question>()
                .HasMany(e => e.Answers)
                .WithOne(e => e.Question)
                .HasForeignKey(e => e.QuestionId)
                .IsRequired();

            modelBuilder.Entity<Answer>()
                .HasOne(e => e.Question)
                .WithMany(e => e.Answers)
                .HasForeignKey(e => e.QuestionId)
                .IsRequired();


            // Topics/Questions relational mapping: one topic references many questions
            modelBuilder.Entity<Topic>()
                .HasMany(e => e.Question)
                .WithOne(e => e.Topic)
                .HasForeignKey(e => e.TopicId)
                .IsRequired();

            modelBuilder.Entity<Question>()
                .HasOne(e => e.Topic)
                .WithMany(e => e.Question)
                .HasForeignKey(e => e.TopicId)
                .IsRequired();

            // Topic/Lesson mapping. One topic references many lessons. 
            modelBuilder.Entity<Topic>().
                HasMany(e => e.Lesson)
                .WithOne(e => e.Topic).
                HasForeignKey(e => e.TopicId).
                IsRequired();

            modelBuilder.Entity<Lesson>()
                .HasOne(e => e.Topic)
                .WithMany(e => e.Lesson)
                .HasForeignKey(e => e.TopicId)
                .IsRequired();


            // Sections/Topics Mapping: one section references many topics
            // Sections are simply containers. They have no value in themselves.

            modelBuilder.Entity<Section>()
                .HasMany(e => e.Topic)
                .WithOne(e => e.Section)
                .HasForeignKey(e => e.SectionId)
                .IsRequired();
            modelBuilder.Entity<Topic>()
                .HasOne(e => e.Section)
                .WithMany(e => e.Topic)
                .HasForeignKey(e => e.SectionId)
                .IsRequired();


            // Course/Section mapping, one course references many topics.
            modelBuilder.Entity<Course>()
                .HasMany(e => e.Section)
                .WithOne(e => e.Course)
                .HasForeignKey(e => e.CourseId)
                .IsRequired();
            modelBuilder.Entity<Section>()
                .HasOne(e => e.Course)
                .WithMany(e => e.Section)
                .HasForeignKey(e => e.CourseId)
                .IsRequired();


            modelBuilder.Entity<Question>().ToTable("Question");
            modelBuilder.Entity<Lesson>().ToTable("Lesson");
            modelBuilder.Entity<Topic>().ToTable("Topic");
            modelBuilder.Entity<Section>().ToTable("Section");
            modelBuilder.Entity<Course>().ToTable("Course");

            modelBuilder.Seed();
        }
    }
}
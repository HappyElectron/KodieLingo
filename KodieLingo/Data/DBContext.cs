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

            // Trying the one-to-many question/answer relationship
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

            modelBuilder.Entity<Question>().ToTable("Question");

            modelBuilder.Seed();

            /* FAILED Courses table initialisation
             * Included in case i want to check back later and salvage
             * Ignore
            modelBuilder.Entity<Course>()
            .ToTable("Course");


            // This is some BS. No chance we have do deal with this nonsense for every course.
            // Will be a nightmare. I'll redesign it later ig.
            modelBuilder.Entity<Course>().HasData(new Course()
            {
                Id = 0,
                Name = "C#",
                Description = "C# is an object-oriented, memory-safe  language, built on the .NET framework " +
                "and maintained by Microsoft. It covers a wide range of applications, from websites, to desktop " +
                "applications, to other stuff, probably.",
                Sections = { new Section() { Id = 0,
                    Name = "Procedural programming",
                    Description = "The beninging",
                    Topics = { new Topic()
                    {
                        Id = 0,
                        Name = "How computers read code",
                        Guidebook = "They read code sequentially. Don't be a dummy, etc",
                        Questions = {
                            new Question() { Id = 0,
                                QuestionString = "Why is my group not doing anything?",
                                Answers = { { 0, "I’m controlling and hard to work with" },
                                    { 1, "I have not communicated my needs effectively" },
                                    { 2, "I have overestimated my own output" },
                                    { 3, "IDK their fault" } },
                                ValidAnswers = { 3 }
                            } },
                        Lessons = { new Lesson()
                        {
                            Id = 0,
                            Difficulty = 1,
                        } }
                    } }
                }
                }
            });*/
        }
    }
}
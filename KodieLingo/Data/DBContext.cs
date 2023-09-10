using KodieLingo.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Emit;
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
        public DbSet<Course> Courses { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
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

			MapRelations(modelBuilder);

			// Table initialisations
			modelBuilder.Entity<User>().ToTable("User");
			modelBuilder.Entity<Question>().ToTable("Question");
            modelBuilder.Entity<Lesson>().ToTable("Lesson");
            modelBuilder.Entity<Topic>().ToTable("Topic");
            modelBuilder.Entity<Section>().ToTable("Section");
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Tag>().ToTable("Tag");

            modelBuilder.Seed();
        }

        // Method to clean up OnModelCreating: Map relations between tables
        private static void MapRelations(ModelBuilder modelBuilder)
        {

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

			// Course/Tag mapping, many courses reference many tags
			modelBuilder.Entity<Course>()
				.HasMany(e => e.Tag)
				.WithMany(e => e.Course);
			modelBuilder.Entity<Tag>()
				.HasMany(e => e.Course)
				.WithMany(e => e.Tag);

			// User/Course mapping, many users reference many courses
			modelBuilder.Entity<Course>()
				.HasMany(e => e.User)
				.WithMany(e => e.Course);
			modelBuilder.Entity<User>()
				.HasMany(e => e.Course)
				.WithMany(e => e.User);


            // Friend/User mapping: circular. Maybe just vibe with this tbh.
            modelBuilder.Entity<User>()
				.HasMany(e => e.Friend)
				.WithMany(e => e.FriendParents);

			// Friend request mapping.
			// EF has saved the incoming join table as UserUser1, and out as UserUser2. Although that's shit,
			// I cannot be bothered changing it rn, so maybe, like, l8rs sk8rs.
			modelBuilder.Entity<User>()
				.HasMany(e => e.FriendReqIncoming)
				.WithMany(e => e.FriendReqIncomingParents);
            modelBuilder.Entity<User>()
				.HasMany(e => e.FriendReqOutgoing)
				.WithMany(e => e.FriendReqOutgoingParents);


            // Course prereuisite mapping, many courses may reference many courses
            // This structure is one big pile of horseshit.
            modelBuilder.Entity<Course>()
                .HasMany(e => e.Prerequisite)
                .WithMany(e => e.PrerequisiteParent);
        }
    }
}
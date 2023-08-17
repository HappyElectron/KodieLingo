﻿// <auto-generated />
using KodieLingo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KodieLingo.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230817121156_SectionCourse2")]
    partial class SectionCourse2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("KodieLingo.Model.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AnswerString")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsValid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuestionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnswerString = "Ned's fault",
                            IsValid = false,
                            QuestionId = 1
                        },
                        new
                        {
                            Id = 2,
                            AnswerString = "Aiden's fault",
                            IsValid = true,
                            QuestionId = 1
                        });
                });

            modelBuilder.Entity("KodieLingo.Model.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Course", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A super fun language to code in with your best buds ever",
                            Name = "C#"
                        });
                });

            modelBuilder.Entity("KodieLingo.Model.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Difficulty")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsTest")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TopicId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.ToTable("Lesson", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Difficulty = 5,
                            IsTest = false,
                            TopicId = 1
                        });
                });

            modelBuilder.Entity("KodieLingo.Model.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("QuestionString")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TopicId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.ToTable("Question", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            QuestionString = "Why",
                            TopicId = 1
                        });
                });

            modelBuilder.Entity("KodieLingo.Model.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Section", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            Description = "Learning how computers interpret commands",
                            Name = "Procedural Programming"
                        });
                });

            modelBuilder.Entity("KodieLingo.Model.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Guidebook")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SectionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.ToTable("Topic", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Guidebook = "Don't be an idiot, type the words.",
                            Name = "If Statements",
                            SectionId = 1
                        });
                });

            modelBuilder.Entity("KodieLingo.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("LifetimeKB")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LongestStreak")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Streak")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("WeeklyKB")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "FrenchMommy@dosomeworkaiden.punk",
                            LifetimeKB = 0,
                            LongestStreak = 0,
                            Password = "Who cares if it's public and unsanitized",
                            Streak = 0,
                            Username = "Aiden's Mom",
                            WeeklyKB = 0
                        });
                });

            modelBuilder.Entity("KodieLingo.Model.Answer", b =>
                {
                    b.HasOne("KodieLingo.Model.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("KodieLingo.Model.Lesson", b =>
                {
                    b.HasOne("KodieLingo.Model.Topic", "Topic")
                        .WithMany("Lesson")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("KodieLingo.Model.Question", b =>
                {
                    b.HasOne("KodieLingo.Model.Topic", "Topic")
                        .WithMany("Question")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("KodieLingo.Model.Section", b =>
                {
                    b.HasOne("KodieLingo.Model.Course", "Course")
                        .WithMany("Section")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("KodieLingo.Model.Topic", b =>
                {
                    b.HasOne("KodieLingo.Model.Section", "Section")
                        .WithMany("Topic")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Section");
                });

            modelBuilder.Entity("KodieLingo.Model.Course", b =>
                {
                    b.Navigation("Section");
                });

            modelBuilder.Entity("KodieLingo.Model.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("KodieLingo.Model.Section", b =>
                {
                    b.Navigation("Topic");
                });

            modelBuilder.Entity("KodieLingo.Model.Topic", b =>
                {
                    b.Navigation("Lesson");

                    b.Navigation("Question");
                });
#pragma warning restore 612, 618
        }
    }
}

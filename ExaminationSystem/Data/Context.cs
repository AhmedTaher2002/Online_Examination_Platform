using ExaminationSystem.Models;
using ExaminationSystem.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ExaminationSystem.Data
{
    public class Context : DbContext
    {
        // Parameterless constructor added so code that does `new Context()` compiles.
        // Prefer injecting `Context` via DI and removing parameterless usage in repositories.
        public Context() { }

        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAnswer> StudentAnswers { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<StudentExam> StudentExam { get; set; }
        public DbSet<RoleFeature> RoleFeature { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Only configure here if options were not provided (design-time / direct new Context() scenarios).
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = ExaminationSystemDB; Integrated Security = True; Trust Server Certificate = True")
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                    .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
                    .EnableSensitiveDataLogging(true);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(c => c.ID);
                entity.Property(entity => entity.CreatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(entity => entity.UpdatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(entity => entity.IsDeleted).HasDefaultValue(false);
            });
            modelBuilder.Entity<Exam>(entity =>
            {
                entity.HasKey(c => c.ID);
                entity.Property(entity => entity.CreatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(entity => entity.UpdatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(entity => entity.IsDeleted).HasDefaultValue(false);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(c => c.ID);
                entity.Property(entity => entity.CreatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(entity => entity.UpdatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(entity => entity.IsDeleted).HasDefaultValue(false);
            });
            modelBuilder.Entity<Choice>(entity =>
            {
                entity.HasKey(c => c.ID);
                entity.Property(entity => entity.CreatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(entity => entity.UpdatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(entity => entity.IsDeleted).HasDefaultValue(false);

                // Explicitly configure relationship to Question and disable cascade delete
                // to avoid multiple cascade paths reaching StudentAnswers.
                entity.HasOne(c => c.Question)
                      .WithMany(q => q.Choices) // ensure Question has ICollection<Choice> Choices
                      .HasForeignKey(c => c.QuestionId)
                      .OnDelete(DeleteBehavior.NoAction);
            });



            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.ToTable("Instructors");
                entity.HasKey(c => c.ID);

                entity.Property(entity => entity.CreatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(entity => entity.UpdatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(entity => entity.IsDeleted).HasDefaultValue(false);

                entity.HasIndex(u => u.Email).IsUnique();
                entity.HasIndex(u => u.Username).IsUnique();

                entity.HasMany(i => i.Courses)
                      .WithOne(c => c.Instructor)
                      .HasForeignKey(c => c.InstructorId).OnDelete(DeleteBehavior.NoAction);
                entity.HasMany(i => i.Questions)
                      .WithOne(q => q.Instructor)
                      .HasForeignKey(q => q.InstructorId).OnDelete(DeleteBehavior.NoAction);
                entity.Property(i => i.Role).HasDefaultValue(Role.Instructor);
            });
            modelBuilder.Entity<Student>(entity => 
            {
                entity.ToTable("Students");
                entity.HasKey(c => c.ID);

                entity.Property(entity => entity.CreatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(entity => entity.UpdatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(entity => entity.IsDeleted).HasDefaultValue(false);

                entity.HasIndex(u => u.Email).IsUnique();
                entity.HasIndex(u => u.Username).IsUnique();
                entity.Property(i => i.Role).HasDefaultValue(Role.Student);
                entity.HasMany(s => s.StudentCourses)
                      .WithOne(sc => sc.Student)
                      .HasForeignKey(sc => sc.StudentId).OnDelete(DeleteBehavior.NoAction);
                entity.HasMany(s => s.StudentExams).WithOne(a=>a.Student)
                       .HasForeignKey(se=>se.StudentId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<ExamQuestion>(entity =>
            {
                entity.HasKey(eq => new { eq.ExamId, eq.QuestionId });
                entity.HasOne(eq => eq.Exam)
                      .WithMany(e => e.ExamQuestions)
                      .HasForeignKey(eq => eq.ExamId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(eq => eq.Question).WithMany(q => q.ExamQuestions)
                      .HasForeignKey(eq => eq.QuestionId).OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<StudentAnswer>(entity =>
            {
                entity.HasKey(sa => new { sa.QuestionId, sa.StudentId, sa.ExamId });

                entity.HasOne(sa => sa.StudentExam)
                      .WithMany(se => se.Answers)
                      .HasForeignKey(sa => new { sa.StudentId, sa.ExamId })
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(sa => sa.Question)
                      .WithMany(q => q.StudentAnswers)
                      .HasForeignKey(sa => sa.QuestionId)
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(sa => sa.Exam)
                      .WithMany()
                      .HasForeignKey(sa => sa.ExamId)
                      .OnDelete(DeleteBehavior.NoAction);

            });
            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(sc => new { sc.StudentId, sc.CourseId });
                entity.HasOne(sc => sc.Student)
                      .WithMany(s => s.StudentCourses)
                      .HasForeignKey(sc => sc.StudentId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(sc => sc.Course).WithMany(c => c.StudentCourses)
                      .HasForeignKey(sc => sc.CourseId).OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<StudentExam>(entity =>
            {
                entity.HasKey(se => new { se.StudentId, se.ExamId });
                entity.HasOne(se => se.Student)
                      .WithMany(s => s.StudentExams)
                      .HasForeignKey(se => se.StudentId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(se => se.Exam).WithMany(e => e.StudentExams)
                      .HasForeignKey(se => se.ExamId).OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<RoleFeature>(entity =>
            {
                entity.HasKey(rf => new { rf.Role, rf.Feature });
            });
            
        }
    }
}

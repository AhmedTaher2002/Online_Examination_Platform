using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ExaminationSystem.Data
{
    public class Context : DbContext
    {
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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source = (localdb)\MSSQLLocalDB; initial catalog =ExaminationDB ; integrated security = true; trust server certificate = true ")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
                .EnableSensitiveDataLogging(true);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity => { 
                entity.HasKey(c => c.ID);
                entity.Property(entity=> entity.CreatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(entity=> entity.UpdatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(entity=> entity.IsDeleted).HasDefaultValue(false);
            });
            modelBuilder.Entity<Exam>(entity => {
                entity.HasKey(c => c.ID);
                entity.Property(entity => entity.CreatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(entity => entity.UpdatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(entity => entity.IsDeleted).HasDefaultValue(false);
            });

            modelBuilder.Entity<Question>(entity => {
                entity.HasKey(c => c.ID);
                entity.Property(entity => entity.CreatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(entity => entity.UpdatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(entity => entity.IsDeleted).HasDefaultValue(false);
            });
            modelBuilder.Entity<Choice>(entity => {
                entity.HasKey(c => c.ID);
                entity.Property(entity => entity.CreatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(entity => entity.UpdatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(entity => entity.IsDeleted).HasDefaultValue(false);
            });
            modelBuilder.Entity<Instructor>(entity => {
                entity.HasKey(c => c.ID);
                entity.Property(entity => entity.CreatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(entity => entity.UpdatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(entity => entity.IsDeleted).HasDefaultValue(false);
            });
            modelBuilder.Entity<Student>(entity => {
                entity.HasKey(c => c.ID);
                entity.Property(entity => entity.CreatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(entity => entity.UpdatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(entity => entity.IsDeleted).HasDefaultValue(false);
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
                entity.HasKey(sa => new { sa.QuestionId,sa.StudentId,sa.ExamId });  
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
            modelBuilder.Entity<StudentCourse>(entity => {
                entity.HasKey(sc => new { sc.StudentId, sc.CourseId });
                entity.HasOne(sc => sc.Student)
                      .WithMany(s => s.StudentCourses)
                      .HasForeignKey(sc => sc.StudentId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(sc => sc.Course).WithMany(c => c.StudentCourses)
                      .HasForeignKey(sc => sc.CourseId).OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<StudentExam>(entity => {
                entity.HasKey(se => new { se.StudentId, se.ExamId });
                entity.HasOne(se => se.Student)
                      .WithMany(s => s.StudentExams)
                      .HasForeignKey(se => se.StudentId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(se => se.Exam).WithMany(e => e.StudentExams)
                      .HasForeignKey(se => se.ExamId).OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}

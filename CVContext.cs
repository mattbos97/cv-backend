using cv_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace cv_backend;

public class CVContext : DbContext
{
    public CVContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<WorkExperience> WorkExperiences { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        DefinePersonWorkExperienceRelationship(modelBuilder);

        DefinePersonSkillRelationship(modelBuilder);
        
        base.OnModelCreating(modelBuilder);
    }

    private static void DefinePersonWorkExperienceRelationship(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .HasMany<WorkExperience>(person => person.WorkExperiences)
            .WithOne(experience => experience.Person)
            .HasForeignKey(experience => experience.PersonId)
            .IsRequired();
    }

    private void DefinePersonSkillRelationship(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person_Skill>()
            .HasKey(ps => new { ps.PersonId, ps.SkillId });

        modelBuilder.Entity<Person_Skill>()
            .HasOne<Person>(ps => ps.Person)
            .WithMany(person => person.PersonSkills)
            .HasForeignKey(ps => ps.PersonId)
            .IsRequired();

        modelBuilder.Entity<Person_Skill>()
            .HasOne<Skill>(ps => ps.Skill)
            .WithMany(skill => skill.PersonSkills)
            .HasForeignKey(ps => ps.SkillId)
            .IsRequired();
    }

public DbSet<cv_backend.Models.Skill> Skill { get; set; } = default!;

}
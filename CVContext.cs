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
    public DbSet<Skill> Skills { get; set; }
    public DbSet<PersonSkill> PersonSkills { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        DefineWorkExperienceModel(modelBuilder);
        DefinePersonSkillModel(modelBuilder);
        
        base.OnModelCreating(modelBuilder);
    }

    private static void DefineWorkExperienceModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WorkExperience>()
            .HasOne<Person>(w => w.Person)
            .WithMany(p => p.WorkExperiences)
            .HasForeignKey(w => w.PersonId)
            .IsRequired();
    }

    private void DefinePersonSkillModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PersonSkill>()
            .HasKey(ps => new { ps.PersonId, ps.SkillId });

        modelBuilder.Entity<PersonSkill>()
            .HasOne<Person>(ps => ps.Person)
            .WithMany(person => person.PersonSkills)
            .HasForeignKey(ps => ps.PersonId)
            .IsRequired();

        modelBuilder.Entity<PersonSkill>()
            .HasOne<Skill>(ps => ps.Skill)
            .WithMany(skill => skill.PersonSkills)
            .HasForeignKey(ps => ps.SkillId)
            .IsRequired();
    }

}
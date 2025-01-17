using System.ComponentModel.DataAnnotations;

namespace cv_backend.Models;

public class Person
{
    
    public long Id { get; set; }
    [MaxLength(50)]
    public required string FirstName { get; set; }
    [MaxLength(50)]
    public required string LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public required string Bio { get; set; }
    
    public ICollection<WorkExperience> WorkExperiences { get; set; } = [];
    public ICollection<PersonSkill> PersonSkills { get; set; } = [];

}
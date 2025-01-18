using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace cv_backend.Models;

public class Person
{
    
    public long Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public required string FirstName { get; set; }
    
    [Required]
    [MaxLength(50)]
    public required string LastName { get; set; }
    
    public DateOnly DateOfBirth { get; set; }
    
    public required string Bio { get; set; }
    
    [JsonIgnore]
    public ICollection<WorkExperience> WorkExperiences { get; set; } = [];
    [JsonIgnore]
    public ICollection<PersonSkill> PersonSkills { get; set; } = [];

}
using System.ComponentModel.DataAnnotations;

namespace cv_backend.Models;

public class Skill
{

    public long Id { get; set; }
    [MaxLength(50)]
    public required string Name { get; set; }

    public ICollection<Person_Skill> PersonSkills { get; set; } = [];

}
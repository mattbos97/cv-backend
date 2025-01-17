using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace cv_backend.Models;

public class Skill
{

    public long Id { get; set; }
    [MaxLength(50)]
    public required string Name { get; set; }

    [JsonIgnore]
    public ICollection<PersonSkill> PersonSkills { get; set; } = [];

}
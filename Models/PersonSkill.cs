using System.Text.Json.Serialization;

namespace cv_backend.Models;

public class PersonSkill
{

    public long PersonId { get; set; }
    [JsonIgnore]
    public Person? Person { get; set; }
    
    public long SkillId { get; set; }
    [JsonIgnore]
    public Skill? Skill { get; set; }
    
    public SkillLevel Level { get; set; }

}

public enum SkillLevel
{

    BEGINNER, INTERMEDIATE, EXPERT, PRO

}
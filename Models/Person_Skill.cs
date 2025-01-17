namespace cv_backend.Models;

public class Person_Skill
{

    public long PersonId { get; set; }
    public required Person Person { get; set; }
    
    public long SkillId { get; set; }
    public required Skill Skill { get; set; }
    
    public SkillLevel Level { get; set; }

}

public enum SkillLevel
{

    BEGINNER, INTERMEDIATE, EXPERT, PRO

}
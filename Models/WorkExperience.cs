using System.ComponentModel.DataAnnotations;

namespace cv_backend.Models;

public class WorkExperience
{

    public long Id { get; set; }
    
    [MaxLength(50)]
    public required string JobTitle { get; set; }
    [MaxLength(50)]
    public required string CompanyName { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public required string JobDescription { get; set; }
    
    public long PersonId { get; set; }
    public required Person Person { get; set; }

}
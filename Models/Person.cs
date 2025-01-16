namespace cv_backend.Models;

public class Person
{

    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }

}
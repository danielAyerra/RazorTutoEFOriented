using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RazorTutoEFOriented.Models;

public class OfficeAssigment
{
    [Key]
    public int InstructorID { get; set; }
    
    [StringLength(50)]
    [Display(Name = "Office Location")]
    public string Location { get; set; }
    
    public Instructor Instructor { get; set; }
}
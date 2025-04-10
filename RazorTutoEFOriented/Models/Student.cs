namespace RazorTutoEFOriented.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Student
{
    public int ID { get; set; }
    
    [StringLength(50)]
    [Display(Name = "Last Name")]
    [Required]
    [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
    public string LastName { get; set; }
    
    [Required]
    [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
    [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
    [Display(Name = "First Name")]
    [Column("FirstName")]
    public string FirstMidName { get; set; }
    
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Enrollment Date")]
    public DateTime EnrollmentDate { get; set; }

    [Display(Name = "Full Name")]
    public string FullName
    {
        get
        {
            return $"{LastName}, {FirstMidName}";
        }
    }
    public ICollection<Enrollment>? Enrollments { get; set; }
}
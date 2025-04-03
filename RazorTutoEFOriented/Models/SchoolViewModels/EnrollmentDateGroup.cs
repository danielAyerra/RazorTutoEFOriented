using System;
using System.ComponentModel.DataAnnotations;

namespace RazorTutoEFOriented.Models.SchoolViewModels;

public class EnrollmentDateGroup
{
    [DataType(DataType.Date)]
    public DateTime? EnrollmentDate { get; set; }
    public int StudentsCount { get; set; }
}
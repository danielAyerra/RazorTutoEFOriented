using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTutoEFOriented.Data;
using RazorTutoEFOriented.Models.SchoolViewModels;

namespace RazorTutoEFOriented.Models;

public class InstructorCoursesPageModel : PageModel
{
    public List<AssignedCourseData> AssignedCourseDataList;
    public void PopulateAssignedCourseData(SchoolContext context, 
                                            Instructor instructor)
    {
        var allCourses = context.Courses;
        var instructorCourses = new HashSet<int>(
            instructor.Courses.Select(c => c.CourseID));
        AssignedCourseDataList = new List<AssignedCourseData>();
        foreach (var course in allCourses)
        {
            AssignedCourseDataList.Add(new AssignedCourseData
            {
                CourseID = course.CourseID,
                Title = course.Title,
                Assigned = instructorCourses.Contains(course.CourseID)
            });
        }
    }
}
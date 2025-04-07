using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorTutoEFOriented.Data;
using RazorTutoEFOriented.Models;
using RazorTutoEFOriented.Models.SchoolViewModels;

namespace RazorTutoEFOriented.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly RazorTutoEFOriented.Data.SchoolContext _context;

        public IndexModel(RazorTutoEFOriented.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<CourseViewModel> CourseVM { get;set; }

        public async Task OnGetAsync()
        {
            CourseVM = await _context.Courses
                .Select(p=>new CourseViewModel
                {
                    CourseID = p.CourseID,
                    Title = p.Title,
                    Credits = p.Credits,
                    DepartmentName = p.Department.Name
                })
                .ToListAsync();
        }
    }
}

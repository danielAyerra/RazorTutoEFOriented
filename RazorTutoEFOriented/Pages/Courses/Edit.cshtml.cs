using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorTutoEFOriented.Data;
using RazorTutoEFOriented.Models;

namespace RazorTutoEFOriented.Pages.Courses
{
    public class EditModel : DepartmentNamePageModel
    {
        private readonly RazorTutoEFOriented.Data.SchoolContext _context;

        public EditModel(RazorTutoEFOriented.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course =  await _context.Courses
                        .Include(c=>c.Department)
                        .FirstOrDefaultAsync(m => m.CourseID == id);
            if (Course == null)
            {
                return NotFound();
            }
            PopulateDepartmentsDropDownList(_context, Course.DepartmentID);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseToUpdate = await _context.Courses.FindAsync(id);

            if (courseToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Course>(
                    courseToUpdate,
                    "course",
                    c => c.Credits,
                    c => c.DepartmentID,
                    c => c.Title))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateDepartmentsDropDownList(_context, courseToUpdate.DepartmentID);
            return Page();
        }
    }
}

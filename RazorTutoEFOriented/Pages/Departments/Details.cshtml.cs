using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorTutoEFOriented.Data;
using RazorTutoEFOriented.Models;

namespace RazorTutoEFOriented.Pages.Departments
{
    public class DetailsModel : PageModel
    {
        private readonly RazorTutoEFOriented.Data.SchoolContext _context;

        public DetailsModel(RazorTutoEFOriented.Data.SchoolContext context)
        {
            _context = context;
        }

        public Department Department { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments.FirstOrDefaultAsync(m => m.DepartmentID == id);

            if (department is not null)
            {
                Department = department;

                return Page();
            }

            return NotFound();
        }
    }
}

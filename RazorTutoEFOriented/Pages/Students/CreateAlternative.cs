/// ##############################################################################
/// # 
/// #         An alternative to avoid overposting at the create page             #
/// #
/// ##############################################################################
///
/// There is an alternative to TryUpdateModelAsync so that instead of using Student
/// model, an special model with less attributes, which must be used at Create.cshtml.
/// The code for Create.cshtml.cs is shown below, together with StudentVM ViewModel,
/// which should be in another folder (ViewModels) in order to avoid interferences 
/// with the Domain Model.


/*
namespace RazorTutoEFOriented.Pages.Students;

public class StudentVM
{
    public int ID { get; set; }
    public string LastName { get; set; }
    public string FirstMidName { get; set; }
    public DateTime EnrollmentDate { get; set; }
}
public class CreateAlternative
{
    [BindProperty]
    public StudentVM StudentVM { get; set; }
///blah
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var entry = _context.Add(new Student());
        entry.CurrentValues.SetValues(StudentVM);
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
    }
}
*/
using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes;

[BindProperties]
public class CreateModel : PageModel
{
	private readonly ApplicationDbContext _context;

	public FoodType FoodType { get; set; }

    public CreateModel(ApplicationDbContext context)
    {
		_context = context;
    }
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
      
        if (ModelState.IsValid)
        {
		    await _context.FoodType.AddAsync(FoodType);
			await _context.SaveChangesAsync();
			TempData["success"] = "FoodType created successfully";
            return RedirectToPage("Index");
        }
        return Page();
    }
}

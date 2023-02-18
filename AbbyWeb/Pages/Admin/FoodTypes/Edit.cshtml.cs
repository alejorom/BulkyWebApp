using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes;

[BindProperties]
public class EditModel : PageModel
{
	private readonly ApplicationDbContext _context;

	public FoodType FoodType { get; set; }

    public EditModel(ApplicationDbContext context)
    {
		_context = context;
    }
    public void OnGet(int id)
    {
        FoodType = _context.FoodType.Find(id);
	}

    public async Task<IActionResult> OnPost()
    {
		if (ModelState.IsValid)
		{
			_context.FoodType.Update(FoodType);
			await _context.SaveChangesAsync();
			TempData["success"] = "Food Type updated successfully";
			return RedirectToPage("Index");
		}
		return Page();
    }
}

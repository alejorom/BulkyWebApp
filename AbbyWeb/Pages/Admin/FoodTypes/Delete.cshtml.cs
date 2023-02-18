using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes;

[BindProperties]
public class DeleteModel : PageModel
{
	private readonly ApplicationDbContext _context;

	public FoodType FoodType { get; set; }

    public DeleteModel(ApplicationDbContext context)
    {
		_context = context;
    }
    public void OnGet(int id)
    {
        FoodType = _context.FoodType.Find(id);
	}

    public async Task<IActionResult> OnPost()
    {
		var foodTypeFromDb = _context.FoodType.Find(FoodType.Id);
		if (foodTypeFromDb != null)
		{
			_context.FoodType.Remove(foodTypeFromDb);
			await _context.SaveChangesAsync();
			TempData["success"] = "Food Type deleted successfully";
			return RedirectToPage("Index");
		}

		return Page();
    }
}

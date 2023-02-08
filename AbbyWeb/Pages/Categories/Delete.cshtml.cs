using AbbyWeb.Abby.DataAccess.Data;
using AbbyWeb.Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
	[BindProperties]
	public class DeleteModel : PageModel
    {
		private readonly ApplicationDbContext _context;

		public Category Category { get; set; }

		public DeleteModel(ApplicationDbContext context)
		{
			_context = context;
		}

		public void OnGet(int id)
        {
			Category = _context.Category.Find(id);
		}

		public async Task<IActionResult> OnPost()
		{
			var categoryFromDb = _context.Category.Find(Category.Id);
			if (categoryFromDb != null)
			{
				_context.Category.Remove(categoryFromDb);
				await _context.SaveChangesAsync();
				TempData["success"] = "Category deleted successfully";
				return RedirectToPage("Index");
			}

			return Page();
		}
	}
}

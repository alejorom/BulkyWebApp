using AbbyWeb.Abby.DataAccess.Data;
using AbbyWeb.Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
	[BindProperties]
	public class CreateModel : PageModel
    {
		private readonly ApplicationDbContext _context;
		public Category Category { get; set; }

		public CreateModel(ApplicationDbContext context)
		{
			_context = context;
		}

		public void OnGet()
		{
		}

		public async Task<IActionResult> OnPost()
		{
			if (Category.Name == Category.DisplayOrder.ToString())
			{
				ModelState.AddModelError("Category.Name", "The DisplayOrder cannot exactly match the Name.");
			}
			if (ModelState.IsValid)
			{
				await _context.Category.AddAsync(Category);
				await _context.SaveChangesAsync();
				return RedirectToPage("Index");
			}
			return Page();

		}
	}
}

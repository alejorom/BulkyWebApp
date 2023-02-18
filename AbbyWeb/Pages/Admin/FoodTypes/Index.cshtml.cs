using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes;

public class IndexModel : PageModel
{
	private readonly ApplicationDbContext _context;

	public IEnumerable<FoodType> FoodTypes { get; set; }

    public IndexModel(ApplicationDbContext context)
    {
		_context = context;
    }
    

    public void OnGet()
    {
        FoodTypes = _context.FoodType;
    }
}

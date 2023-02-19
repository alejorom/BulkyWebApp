using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;

namespace Abby.DataAccess.Repository
{
	public class FoodTypeRepository : Repository<FoodType>, IFoodTypeRepository
	{
		private readonly ApplicationDbContext _context;

		public FoodTypeRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}

		public void Update(FoodType foodType)
		{
			var objFromDb = _context.FoodType.FirstOrDefault(u => u.Id == foodType.Id);
			objFromDb.Name = foodType.Name;
		}
	}
}

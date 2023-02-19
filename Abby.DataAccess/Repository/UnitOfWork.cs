using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;

namespace Abby.DataAccess.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;

		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
			Category = new CategoryRepository(_context);
			FoodType = new FoodTypeRepository(_context);
		}

		public ICategoryRepository Category { get; set; }
		public IFoodTypeRepository FoodType { get; set; }

		public void Dispose()
		{
			_context.Dispose();
		}

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}

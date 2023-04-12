using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;

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
			MenuItem = new MenuItemRepository(_context);
			ShoppingCart = new ShoppingCartRepository(_context);
			OrderDetail = new OrderDetailRepository(_context);
			OrderHeader = new OrderHeaderRepository(_context);
		}

		public ICategoryRepository Category { get; private set; }
		public IFoodTypeRepository FoodType { get; private set; }
		public IMenuItemRepository MenuItem { get; private set; }
		public IShoppingCartRepository ShoppingCart { get; private set; }
		public IOrderHeaderRepository OrderHeader { get; private set; }
		public IOrderDetailRepository OrderDetail { get; private set; }
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

using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;

namespace Abby.DataAccess.Repository
{
	public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDbContext _context;

        public ShoppingCartRepository(ApplicationDbContext context) : base(context)
        {
			_context = context;
        }

		public int DecrementCount(ShoppingCart shoppingCart, int count)
		{
			shoppingCart.Count -= count;
			_context.SaveChanges();
			return shoppingCart.Count;
		}

		public int IncrementCount(ShoppingCart shoppingCart, int count)
		{
			shoppingCart.Count += count;
			_context.SaveChanges();
			return shoppingCart.Count;
		}
	}
}

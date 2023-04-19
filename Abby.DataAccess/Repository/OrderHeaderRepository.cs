using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;

namespace Abby.DataAccess.Repository
{
	public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderHeaderRepository(ApplicationDbContext context) : base(context)
        {
			_context = context;
        }
       
        public void Update(OrderHeader orderHeader)
        {
			_context.OrderHeader.Update(orderHeader);
        }

        public void UpdateStatus(int id, string status)
        {
            var orderFromDb = _context.OrderHeader.FirstOrDefault(u => u.Id == id);
            if (orderFromDb != null) orderFromDb.Status = status;
        }
    }
}

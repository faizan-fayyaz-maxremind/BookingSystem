using BookingSystem.Interfaces.IRepositories;
using BookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Data.Repositories
{
    public class CustomerRepository : GenericRepo<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Customer?> GetByPhoneNumberAsync(string phoneNumber)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.PhoneNumber == phoneNumber);
        }
    }
}

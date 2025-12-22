using BookingSystem.Models;

namespace BookingSystem.Interfaces.IRepositories
{
    public interface ICustomerRepository : IGenericRepo<Customer>
    {
        Task<Customer?> GetByPhoneNumberAsync(string phoneNumber);
    }
}

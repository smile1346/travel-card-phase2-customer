using CustomerService.Models;

namespace CustomerService.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(Guid id);
        Task<Customer?> GetByCustomerIdAsync(string customerId);
        Task<Customer?> GetByEmailAsync(string email);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> CreateAsync(Customer customer);
        Task<Customer> UpdateAsync(Customer customer);
        Task DeleteAsync(Guid id);
        Task<bool> ExistsAsync(string customerId);
    }

    public interface ICardRepository
    {
        Task<Card?> GetByIdAsync(Guid id);
        Task<Card?> GetByCardNoAsync(string cardNo);
        Task<IEnumerable<Card>> GetByCustomerIdAsync(Guid customerId);
        Task<Card> CreateAsync(Card card);
        Task<Card> UpdateAsync(Card card);
        Task DeleteAsync(Guid id);
    }
}
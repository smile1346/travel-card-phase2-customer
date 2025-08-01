using Microsoft.EntityFrameworkCore;
using CustomerService.Data;
using CustomerService.Models;

namespace CustomerService.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _context;

        public CustomerRepository(CustomerDbContext context)
        {
            _context = context;
        }

        public async Task<Customer?> GetByIdAsync(Guid id)
        {
            return await _context.Customers
                .Include(c => c.MBankingProfile)
                .Include(c => c.NonMBankingProfile)
                .Include(c => c.Cards)
                .Include(c => c.Preferences)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Customer?> GetByCustomerIdAsync(string customerId)
        {
            return await _context.Customers
                .Include(c => c.MBankingProfile)
                .Include(c => c.NonMBankingProfile)
                .Include(c => c.Cards)
                .Include(c => c.Preferences)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }

        public async Task<Customer?> GetByEmailAsync(string email)
        {
            return await _context.Customers
                .Include(c => c.MBankingProfile)
                .Include(c => c.NonMBankingProfile)
                .Include(c => c.Cards)
                .Include(c => c.Preferences)
                .FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers
                .Include(c => c.MBankingProfile)
                .Include(c => c.NonMBankingProfile)
                .Include(c => c.Cards)
                .Include(c => c.Preferences)
                .ToListAsync();
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            customer.Id = Guid.NewGuid();
            customer.CustomerId = GenerateCustomerId();
            customer.CreatedAt = DateTime.UtcNow;
            customer.UpdatedAt = DateTime.UtcNow;
            customer.Status = CustomerStatus.Active;

            if (customer.MBankingProfile != null)
            {
                customer.MBankingProfile.Id = Guid.NewGuid();
            }

            if (customer.NonMBankingProfile != null)
            {
                customer.NonMBankingProfile.Id = Guid.NewGuid();
            }

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            customer.UpdatedAt = DateTime.UtcNow;
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteAsync(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                customer.Status = CustomerStatus.Inactive; // Soft delete
                customer.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(string customerId)
        {
            return await _context.Customers.AnyAsync(c => c.CustomerId == customerId);
        }

        private string GenerateCustomerId()
        {
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var random = new Random().Next(1000, 9999);
            return $"CUST{timestamp}{random}";
        }
    }

    public class CardRepository : ICardRepository
    {
        private readonly CustomerDbContext _context;

        public CardRepository(CustomerDbContext context)
        {
            _context = context;
        }

        public async Task<Card?> GetByIdAsync(Guid id)
        {
            return await _context.Cards.FindAsync(id);
        }

        public async Task<Card?> GetByCardNoAsync(string cardNo)
        {
            return await _context.Cards.FirstOrDefaultAsync(c => c.CardNo == cardNo);
        }

        public async Task<IEnumerable<Card>> GetByCustomerIdAsync(Guid customerId)
        {
            return await _context.Cards
                .Where(c => c.CustomerId == customerId && c.Status == CardStatus.Active)
                .ToListAsync();
        }

        public async Task<Card> CreateAsync(Card card)
        {
            card.Id = Guid.NewGuid();
            card.CreatedAt = DateTime.UtcNow;
            card.Status = CardStatus.Active;
            card.MaskedCardNumber = MaskCardNumber(card.CardNo);

            _context.Cards.Add(card);
            await _context.SaveChangesAsync();
            return card;
        }

        public async Task<Card> UpdateAsync(Card card)
        {
            _context.Cards.Update(card);
            await _context.SaveChangesAsync();
            return card;
        }

        public async Task DeleteAsync(Guid id)
        {
            var card = await _context.Cards.FindAsync(id);
            if (card != null)
            {
                card.Status = CardStatus.Cancelled; // Soft delete
                await _context.SaveChangesAsync();
            }
        }

        private static string MaskCardNumber(string cardNo)
        {
            if (cardNo.Length < 8) return cardNo;
            return $"{cardNo[..4]}****{cardNo[^4..]}";
        }
    }
}
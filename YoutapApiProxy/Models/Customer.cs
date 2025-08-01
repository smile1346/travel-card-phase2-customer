namespace CustomerService.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string CustomerId { get; set; } = string.Empty; // External customer ID
        public string CustomerName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MobileNo { get; set; } = string.Empty;
        public CustomerType CustomerType { get; set; }
        public CustomerStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? LastLoginAt { get; set; }
        
        // Navigation properties
        public MBankingCustomer? MBankingProfile { get; set; }
        public NonMBankingCustomer? NonMBankingProfile { get; set; }
        public ICollection<Card> Cards { get; set; } = new List<Card>();
        public ICollection<CustomerPreference> Preferences { get; set; } = new List<CustomerPreference>();
    }

    public class MBankingCustomer
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string BANNo { get; set; } = string.Empty; // Bank Account Number
        public string BranchCode { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public decimal? AccountBalance { get; set; }
        public bool IsAccountActive { get; set; } = true;
        public DateTime AccountOpenDate { get; set; }
        
        public Customer Customer { get; set; } = null!;
    }

    public class NonMBankingCustomer
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string IdentificationType { get; set; } = string.Empty; // Passport, ID, etc.
        public string IdentificationNumber { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        
        public Customer Customer { get; set; } = null!;
    }

    public class Card
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string CardNo { get; set; } = string.Empty;
        public string CardType { get; set; } = string.Empty; // Credit, Debit, Prepaid
        public string CardBrand { get; set; } = string.Empty; // Visa, Mastercard
        public string MaskedCardNumber { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public CardStatus Status { get; set; }
        public decimal? CreditLimit { get; set; }
        public decimal? AvailableBalance { get; set; }
        public string Currency { get; set; } = string.Empty;
        public DateTime IssuedDate { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public Customer Customer { get; set; } = null!;
    }

    public class CustomerPreference
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string PreferenceKey { get; set; } = string.Empty;
        public string PreferenceValue { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        public Customer Customer { get; set; } = null!;
    }

    public enum CustomerType
    {
        MBanking = 1,
        NonMBanking = 2
    }

    public enum CustomerStatus
    {
        Active = 1,
        Inactive = 2,
        Suspended = 3,
        Blocked = 4
    }

    public enum CardStatus
    {
        Active = 1,
        Blocked = 2,
        Expired = 3,
        Cancelled = 4
    }
}
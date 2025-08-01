using CustomerService.Models;

namespace CustomerService.DTOs
{
    public class CreateCustomerRequest
    {
        public string CustomerName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MobileNo { get; set; } = string.Empty;
        public CustomerType CustomerType { get; set; }
        public MBankingProfileDto? MBankingProfile { get; set; }
        public NonMBankingProfileDto? NonMBankingProfile { get; set; }
    }

    public class MBankingProfileDto
    {
        public string BANNo { get; set; } = string.Empty;
        public string BranchCode { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public DateTime AccountOpenDate { get; set; }
    }

    public class NonMBankingProfileDto
    {
        public string IdentificationType { get; set; } = string.Empty;
        public string IdentificationNumber { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
    }

    public class CustomerResponse
    {
        public Guid Id { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MobileNo { get; set; } = string.Empty;
        public CustomerType CustomerType { get; set; }
        public CustomerStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public MBankingProfileDto? MBankingProfile { get; set; }
        public NonMBankingProfileDto? NonMBankingProfile { get; set; }
        public List<CardDto> Cards { get; set; } = new();
        public Dictionary<string, string> Preferences { get; set; } = new();
    }

    public class CardDto
    {
        public Guid Id { get; set; }
        public string CardNo { get; set; } = string.Empty;
        public string CardType { get; set; } = string.Empty;
        public string CardBrand { get; set; } = string.Empty;
        public string MaskedCardNumber { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public CardStatus Status { get; set; }
        public decimal? CreditLimit { get; set; }
        public decimal? AvailableBalance { get; set; }
        public string Currency { get; set; } = string.Empty;
        public DateTime IssuedDate { get; set; }
    }

    public class CreateCardRequest
    {
        public string CardNo { get; set; } = string.Empty;
        public string CardType { get; set; } = string.Empty;
        public string CardBrand { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public decimal? CreditLimit { get; set; }
        public string Currency { get; set; } = string.Empty;
    }

    public class UpdateCustomerRequest
    {
        public string CustomerName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MobileNo { get; set; } = string.Empty;
    }

    public class LoginRequest
    {
        public string CustomerId { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public CustomerResponse Customer { get; set; } = null!;
    }

    public class SetPreferenceRequest
    {
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
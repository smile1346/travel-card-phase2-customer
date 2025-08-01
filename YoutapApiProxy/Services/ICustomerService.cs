using CustomerService.DTOs;

namespace CustomerService.Services
{
    public interface ICustomerService
    {
        Task<CustomerResponse> CreateCustomerAsync(CreateCustomerRequest request);
        Task<CustomerResponse?> GetCustomerByIdAsync(Guid id);
        Task<CustomerResponse?> GetCustomerByCustomerIdAsync(string customerId);
        Task<CustomerResponse?> GetCustomerByEmailAsync(string email);
        Task<IEnumerable<CustomerResponse>> GetAllCustomersAsync();
        Task<CustomerResponse> UpdateCustomerAsync(Guid id, UpdateCustomerRequest request);
        Task DeleteCustomerAsync(Guid id);
        Task<CardDto> AddCardAsync(Guid customerId, CreateCardRequest request);
        Task<IEnumerable<CardDto>> GetCustomerCardsAsync(Guid customerId);
        Task SetCustomerPreferenceAsync(Guid customerId, SetPreferenceRequest request);
        Task<Dictionary<string, string>> GetCustomerPreferencesAsync(Guid customerId);
        Task UpdateLastLoginAsync(string customerId);
    }

    public interface IAuthenticationService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task<string> GenerateTokenAsync(CustomerResponse customer);
        Task<CustomerResponse?> ValidateTokenAsync(string token);
    }
}
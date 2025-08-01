using CustomerService.DTOs;
using CustomerService.Models;
using CustomerService.Repositories;

namespace CustomerService.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICardRepository _cardRepository;

        public CustomerService(ICustomerRepository customerRepository, ICardRepository cardRepository)
        {
            _customerRepository = customerRepository;
            _cardRepository = cardRepository;
        }

        public async Task<CustomerResponse> CreateCustomerAsync(CreateCustomerRequest request)
        {
            var customer = new Customer
            {
                CustomerName = request.CustomerName,
                Email = request.Email,
                MobileNo = request.MobileNo,
                CustomerType = request.CustomerType
            };

            if (request.CustomerType == CustomerType.MBanking && request.MBankingProfile != null)
            {
                customer.MBankingProfile = new MBankingCustomer
                {
                    BANNo = request.MBankingProfile.BANNo,
                    BranchCode = request.MBankingProfile.BranchCode,
                    AccountType = request.MBankingProfile.AccountType,
                    AccountOpenDate = request.MBankingProfile.AccountOpenDate,
                    IsAccountActive = true
                };
            }

            if (request.CustomerType == CustomerType.NonMBanking && request.NonMBankingProfile != null)
            {
                customer.NonMBankingProfile = new NonMBankingCustomer
                {
                    IdentificationType = request.NonMBankingProfile.IdentificationType,
                    IdentificationNumber = request.NonMBankingProfile.IdentificationNumber,
                    Nationality = request.NonMBankingProfile.Nationality,
                    DateOfBirth = request.NonMBankingProfile.DateOfBirth,
                    Address = request.NonMBankingProfile.Address,
                    City = request.NonMBankingProfile.City,
                    Country = request.NonMBankingProfile.Country,
                    PostalCode = request.NonMBankingProfile.PostalCode
                };
            }

            var createdCustomer = await _customerRepository.CreateAsync(customer);
            return MapToCustomerResponse(createdCustomer);
        }

        public async Task<CustomerResponse?> GetCustomerByIdAsync(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            return customer != null ? MapToCustomerResponse(customer) : null;
        }

        public async Task<CustomerResponse?> GetCustomerByCustomerIdAsync(string customerId)
        {
            var customer = await _customerRepository.GetByCustomerIdAsync(customerId);
            return customer != null ? MapToCustomerResponse(customer) : null;
        }

        public async Task<CustomerResponse?> GetCustomerByEmailAsync(string email)
        {
            var customer = await _customerRepository.GetByEmailAsync(email);
            return customer != null ? MapToCustomerResponse(customer) : null;
        }

        public async Task<IEnumerable<CustomerResponse>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            return customers.Select(MapToCustomerResponse);
        }

        public async Task<CustomerResponse> UpdateCustomerAsync(Guid id, UpdateCustomerRequest request)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
                throw new ArgumentException("Customer not found");

            customer.CustomerName = request.CustomerName;
            customer.Email = request.Email;
            customer.MobileNo = request.MobileNo;

            var updatedCustomer = await _customerRepository.UpdateAsync(customer);
            return MapToCustomerResponse(updatedCustomer);
        }

        public async Task DeleteCustomerAsync(Guid id)
        {
            await _customerRepository.DeleteAsync(id);
        }

        public async Task<CardDto> AddCardAsync(Guid customerId, CreateCardRequest request)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null)
                throw new ArgumentException("Customer not found");

            var card = new Card
            {
                CustomerId = customerId,
                CardNo = request.CardNo,
                CardType = request.CardType,
                CardBrand = request.CardBrand,
                ExpiryDate = request.ExpiryDate,
                CreditLimit = request.CreditLimit,
                Currency = request.Currency,
                IssuedDate = DateTime.UtcNow
            };

            var createdCard = await _cardRepository.CreateAsync(card);
            return MapToCardDto(createdCard);
        }

        public async Task<IEnumerable<CardDto>> GetCustomerCardsAsync(Guid customerId)
        {
            var cards = await _cardRepository.GetByCustomerIdAsync(customerId);
            return cards.Select(MapToCardDto);
        }

        public async Task SetCustomerPreferenceAsync(Guid customerId, SetPreferenceRequest request)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null)
                throw new ArgumentException("Customer not found");

            var existingPreference = customer.Preferences.FirstOrDefault(p => p.PreferenceKey == request.Key);
            if (existingPreference != null)
            {
                existingPreference.PreferenceValue = request.Value;
                existingPreference.UpdatedAt = DateTime.UtcNow;
            }
            else
            {
                customer.Preferences.Add(new CustomerPreference
                {
                    Id = Guid.NewGuid(),
                    CustomerId = customerId,
                    PreferenceKey = request.Key,
                    PreferenceValue = request.Value,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                });
            }

            await _customerRepository.UpdateAsync(customer);
        }

        public async Task<Dictionary<string, string>> GetCustomerPreferencesAsync(Guid customerId)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null)
                throw new ArgumentException("Customer not found");

            return customer.Preferences.ToDictionary(p => p.PreferenceKey, p => p.PreferenceValue);
        }

        public async Task UpdateLastLoginAsync(string customerId)
        {
            var customer = await _customerRepository.GetByCustomerIdAsync(customerId);
            if (customer != null)
            {
                customer.LastLoginAt = DateTime.UtcNow;
                await _customerRepository.UpdateAsync(customer);
            }
        }

        private static CustomerResponse MapToCustomerResponse(Customer customer)
        {
            var response = new CustomerResponse
            {
                Id = customer.Id,
                CustomerId = customer.CustomerId,
                CustomerName = customer.CustomerName,
                Email = customer.Email,
                MobileNo = customer.MobileNo,
                CustomerType = customer.CustomerType,
                Status = customer.Status,
                CreatedAt = customer.CreatedAt,
                LastLoginAt = customer.LastLoginAt,
                Cards = customer.Cards.Select(MapToCardDto).ToList(),
                Preferences = customer.Preferences.ToDictionary(p => p.PreferenceKey, p => p.PreferenceValue)
            };

            if (customer.MBankingProfile != null)
            {
                response.MBankingProfile = new MBankingProfileDto
                {
                    BANNo = customer.MBankingProfile.BANNo,
                    BranchCode = customer.MBankingProfile.BranchCode,
                    AccountType = customer.MBankingProfile.AccountType,
                    AccountOpenDate = customer.MBankingProfile.AccountOpenDate
                };
            }

            if (customer.NonMBankingProfile != null)
            {
                response.NonMBankingProfile = new NonMBankingProfileDto
                {
                    IdentificationType = customer.NonMBankingProfile.IdentificationType,
                    IdentificationNumber = customer.NonMBankingProfile.IdentificationNumber,
                    Nationality = customer.NonMBankingProfile.Nationality,
                    DateOfBirth = customer.NonMBankingProfile.DateOfBirth,
                    Address = customer.NonMBankingProfile.Address,
                    City = customer.NonMBankingProfile.City,
                    Country = customer.NonMBankingProfile.Country,
                    PostalCode = customer.NonMBankingProfile.PostalCode
                };
            }

            return response;
        }

        private static CardDto MapToCardDto(Card card)
        {
            return new CardDto
            {
                Id = card.Id,
                CardNo = card.CardNo,
                CardType = card.CardType,
                CardBrand = card.CardBrand,
                MaskedCardNumber = card.MaskedCardNumber,
                ExpiryDate = card.ExpiryDate,
                Status = card.Status,
                CreditLimit = card.CreditLimit,
                AvailableBalance = card.AvailableBalance,
                Currency = card.Currency,
                IssuedDate = card.IssuedDate
            };
        }
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IConfiguration _configuration;

        public AuthenticationService(ICustomerRepository customerRepository, IConfiguration configuration)
        {
            _customerRepository = customerRepository;
            _configuration = configuration;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var customer = await _customerRepository.GetByCustomerIdAsync(request.CustomerId);
            if (customer == null || customer.Status != CustomerStatus.Active)
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            // In a real implementation, you would verify the password hash
            // For demo purposes, we'll assume the login is valid

            var customerResponse = MapToCustomerResponse(customer);
            var token = await GenerateTokenAsync(customerResponse);
            
            // Update last login
            customer.LastLoginAt = DateTime.UtcNow;
            await _customerRepository.UpdateAsync(customer);

            return new LoginResponse
            {
                Token = token,
                ExpiresAt = DateTime.UtcNow.AddHours(24),
                Customer = customerResponse
            };
        }

        public async Task<string> GenerateTokenAsync(CustomerResponse customer)
        {
            // JWT token generation implementation would go here
            // For demo purposes, returning a simple token
            await Task.CompletedTask;
            return $"jwt_token_for_{customer.CustomerId}_{DateTime.UtcNow.Ticks}";
        }

        public async Task<CustomerResponse?> ValidateTokenAsync(string token)
        {
            // JWT token validation implementation would go here
            await Task.CompletedTask;
            return null;
        }

        private static CustomerResponse MapToCustomerResponse(Customer customer)
        {
            // Same mapping logic as in CustomerService
            var response = new CustomerResponse
            {
                Id = customer.Id,
                CustomerId = customer.CustomerId,
                CustomerName = customer.CustomerName,
                Email = customer.Email,
                MobileNo = customer.MobileNo,
                CustomerType = customer.CustomerType,
                Status = customer.Status,
                CreatedAt = customer.CreatedAt,
                LastLoginAt = customer.LastLoginAt,
                Cards = customer.Cards.Select(c => new CardDto
                {
                    Id = c.Id,
                    CardNo = c.CardNo,
                    CardType = c.CardType,
                    CardBrand = c.CardBrand,
                    MaskedCardNumber = c.MaskedCardNumber,
                    ExpiryDate = c.ExpiryDate,
                    Status = c.Status,
                    CreditLimit = c.CreditLimit,
                    AvailableBalance = c.AvailableBalance,
                    Currency = c.Currency,
                    IssuedDate = c.IssuedDate
                }).ToList(),
                Preferences = customer.Preferences.ToDictionary(p => p.PreferenceKey, p => p.PreferenceValue)
            };

            if (customer.MBankingProfile != null)
            {
                response.MBankingProfile = new MBankingProfileDto
                {
                    BANNo = customer.MBankingProfile.BANNo,
                    BranchCode = customer.MBankingProfile.BranchCode,
                    AccountType = customer.MBankingProfile.AccountType,
                    AccountOpenDate = customer.MBankingProfile.AccountOpenDate
                };
            }

            if (customer.NonMBankingProfile != null)
            {
                response.NonMBankingProfile = new NonMBankingProfileDto
                {
                    IdentificationType = customer.NonMBankingProfile.IdentificationType,
                    IdentificationNumber = customer.NonMBankingProfile.IdentificationNumber,
                    Nationality = customer.NonMBankingProfile.Nationality,
                    DateOfBirth = customer.NonMBankingProfile.DateOfBirth,
                    Address = customer.NonMBankingProfile.Address,
                    City = customer.NonMBankingProfile.City,
                    Country = customer.NonMBankingProfile.Country,
                    PostalCode = customer.NonMBankingProfile.PostalCode
                };
            }

            return response;
        }
    }
}
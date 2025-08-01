using Microsoft.AspNetCore.Mvc;
using CustomerService.DTOs;
using CustomerService.Services;

namespace CustomerService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<ActionResult<CustomerResponse>> CreateCustomer([FromBody] CreateCustomerRequest request)
        {
            try
            {
                var customer = await _customerService.CreateCustomerAsync(request);
                return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerResponse>> GetCustomer(Guid id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            return customer != null ? Ok(customer) : NotFound();
        }

        [HttpGet("by-customer-id/{customerId}")]
        public async Task<ActionResult<CustomerResponse>> GetCustomerByCustomerId(string customerId)
        {
            var customer = await _customerService.GetCustomerByCustomerIdAsync(customerId);
            return customer != null ? Ok(customer) : NotFound();
        }

        [HttpGet("by-email/{email}")]
        public async Task<ActionResult<CustomerResponse>> GetCustomerByEmail(string email)
        {
            var customer = await _customerService.GetCustomerByEmailAsync(email);
            return customer != null ? Ok(customer) : NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerResponse>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerResponse>> UpdateCustomer(Guid id, [FromBody] UpdateCustomerRequest request)
        {
            try
            {
                var customer = await _customerService.UpdateCustomerAsync(id, request);
                return Ok(customer);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            await _customerService.DeleteCustomerAsync(id);
            return NoContent();
        }

        [HttpPost("{id}/cards")]
        public async Task<ActionResult<CardDto>> AddCard(Guid id, [FromBody] CreateCardRequest request)
        {
            try
            {
                var card = await _customerService.AddCardAsync(id, request);
                return Created($"/api/customers/{id}/cards/{card.Id}", card);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/cards")]
        public async Task<ActionResult<IEnumerable<CardDto>>> GetCustomerCards(Guid id)
        {
            var cards = await _customerService.GetCustomerCardsAsync(id);
            return Ok(cards);
        }

        [HttpPost("{id}/preferences")]
        public async Task<IActionResult> SetPreference(Guid id, [FromBody] SetPreferenceRequest request)
        {
            try
            {
                await _customerService.SetCustomerPreferenceAsync(id, request);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/preferences")]
        public async Task<ActionResult<Dictionary<string, string>>> GetPreferences(Guid id)
        {
            try
            {
                var preferences = await _customerService.GetCustomerPreferencesAsync(id);
                return Ok(preferences);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authService;

        public AuthController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
        {
            try
            {
                var response = await _authService.LoginAsync(request);
                return Ok(response);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPost("validate")]
        public async Task<ActionResult<CustomerResponse>> ValidateToken([FromHeader] string authorization)
        {
            try
            {
                var token = authorization?.Replace("Bearer ", "");
                if (string.IsNullOrEmpty(token))
                    return Unauthorized();

                var customer = await _authService.ValidateTokenAsync(token);
                return customer != null ? Ok(customer) : Unauthorized();
            }
            catch
            {
                return Unauthorized();
            }
        }
    }
}
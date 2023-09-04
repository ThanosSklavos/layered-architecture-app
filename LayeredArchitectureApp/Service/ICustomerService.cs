using LayeredArchitectureApp.Data;
using LayeredArchitectureApp.DTO;

namespace LayeredArchitectureApp.Service
{
    public interface ICustomerService
    {
        Task<Customer?> InsertCustomer(CustomerCreateDTO customerCreateDTO);
        Task<bool> UpdateCustomer(int id, CustomerUpdateDTO customerUpdateDTO);
        Task<bool?> DeleteCustomer(int id);
        Task<Customer?> GetCustomerById(int id);
        Task<List<Customer>> GetAllCustomers();
    }
}

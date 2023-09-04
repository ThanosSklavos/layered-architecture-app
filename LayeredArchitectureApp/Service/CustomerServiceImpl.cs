using AutoMapper;
using LayeredArchitectureApp.DAO;
using LayeredArchitectureApp.Data;
using LayeredArchitectureApp.DTO;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LayeredArchitectureApp.Service
{
    public class CustomerServiceImpl : ICustomerService
    {
        private readonly ICustomerDAO _customerDAO;
        private readonly IMapper _mapper;

        public CustomerServiceImpl(ICustomerDAO customerDAO, IMapper mapper)
        {
            _customerDAO = customerDAO;
            _mapper = mapper;
        }

        public async Task<Customer?> InsertCustomer(CustomerCreateDTO customerCreateDTO)
        {
            Customer customer = _mapper.Map<Customer>(customerCreateDTO);

            if (GetCustomerById(customer.Id) != null) 
            {
                throw new Exception($"Customer with ID {customer.Id} already exists");
            }
            try
            {
                return await _customerDAO.Insert(customer);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> UpdateCustomer(int id, CustomerUpdateDTO customerUpdateDTO)
        { 
            Customer customer = _mapper.Map<Customer>(customerUpdateDTO);
            if (GetCustomerById(id) == null)
            {
                throw new Exception($"Customer with id {id} not found");
            }

            return await _customerDAO.Update(id, customer);

        }

        public async Task<bool?> DeleteCustomer(int id)
        {
            if (GetCustomerById(id) == null)
            {
                throw new Exception($"Customer with id {id} not found");
            }

            return await _customerDAO.Delete(id);
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            List<Customer> customers = await _customerDAO.GetAll();

            if (customers == null)
            {
                throw new Exception($"Customer list is empty");
            }

            return customers;
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            var customer = await _customerDAO.GetById(id);

            if (customer == null)
            {
                throw new Exception($"Customer with id {id} not found");
            }

            return customer;
        }

        
    }
}

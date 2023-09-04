using LayeredArchitectureApp.Data;
using Microsoft.EntityFrameworkCore;

namespace LayeredArchitectureApp.DAO
{
    public class CustomerDAOImpl : ICustomerDAO
    {
        private readonly LayeredArchitectureTestDbContext _dbContext;

        public CustomerDAOImpl(LayeredArchitectureTestDbContext context)
        {
            _dbContext = context;
        }

        public async Task<Customer?> Insert(Customer customer)
        {
            if (_dbContext.Customers == null)
            {
                return null;
            }
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> Update(int id, Customer customer)
        {
            bool updated;

            if (id != customer.Id)
            {
                return false;
            }
            _dbContext.Entry(customer).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
                updated = true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    updated = false;
                }
                else
                {
                    throw;
                }
            }
            return updated;
        }

        public async Task<bool?> Delete(int id)
        {
            if (_dbContext.Customers == null)
            {
                return false;
            }
            var customer = await _dbContext.Customers.FindAsync(id);
            if(customer == null)
            {
                return false;
            }

            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Customer?> GetById(int id)
        {
            if (_dbContext.Customers == null)
            {
                return null;
            }
            var customer = await _dbContext.Customers.FindAsync(id);

            return customer;
        }

        public async Task<List<Customer>> GetAll()
        {
            if (_dbContext.Customers == null)
            {
                return new List<Customer>();
            }
            return await _dbContext.Customers.ToListAsync();
        }

        private bool CustomerExists(int id)
        {
            return (_dbContext.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}

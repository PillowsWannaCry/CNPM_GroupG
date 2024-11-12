using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KoiOrderingSystem.Repositories
{
    public class KoiOrderCustomerRepository : IKoiOrderCustomerRepository
    {
        private readonly KoiOrderingSystemContext _DbContext;
        public KoiOrderCustomerRepository(KoiOrderingSystemContext DbContext)
        {
            _DbContext = DbContext;
        }

        public bool AddKoiOrderCustomer(KoiOrderCustomer account)
        {
            _DbContext.KoiOrderCustomers.Add(account);
            _DbContext.SaveChanges();
            return true;
        }

        public bool DelKoiOrderCustomer(int Id)
        {
            var customer = _DbContext.KoiOrderCustomers.FirstOrDefault(c => c.CustomerId == Id);
            if (customer != null)
            {
                _DbContext.KoiOrderCustomers.Remove(customer);
                _DbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DelKoiOrderCustomer(KoiOrderCustomer account)
        {
            _DbContext.KoiOrderCustomers.Remove(account);
            _DbContext.SaveChanges();
            return true;
        }

        public async Task<List<KoiOrderCustomer>> GetAllKoiOrderCustomers()
        {
            return await _DbContext.KoiOrderCustomers.ToListAsync();
        }

        public async Task<KoiOrderCustomer> GetKoiOrderCustomerById(int Id)
        {
            return await _DbContext.KoiOrderCustomers.FirstOrDefaultAsync(c => c.CustomerId == Id);
        }
        public bool UpdateKoiOrderCustomer(KoiOrderCustomer account)
        {
            _DbContext.KoiOrderCustomers.Update(account);
            _DbContext.SaveChanges();
            return true;
        }
    }
}
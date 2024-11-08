using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Repositories.Interfaces;
using KoiOrderingSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiOrderingSystem.Repositories;
using Microsoft.EntityFrameworkCore;


namespace KoiOrderingSystem.Services
{
    public class KoiOrderCustomerService : IKoiOrderCustomerService
    {
        private readonly IKoiOrderCustomerRepository _repository;
        public KoiOrderCustomerService(IKoiOrderCustomerRepository repository)
        { 
            _repository = repository;
        }

        public bool AddKoiOrderCustomer(KoiOrderCustomer account)
        {
            return _repository.AddKoiOrderCustomer(account);
        }

        public bool DelKoiOrderCustomer(int Id)
        {
            return _repository.DelKoiOrderCustomer(Id);
        }

        public bool DelKoiOrderCustomer(KoiOrderCustomer account)
        {
            return _repository.DelKoiOrderCustomer(account);
        }

        public async Task<KoiOrderCustomer> GetKoiOrderCustomerById(int Id)
        {
            var customer = await _repository.GetKoiOrderCustomerById(Id);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }
            return customer;
        }

        public  Task<List<KoiOrderCustomer>> KoiOrderCustomers()
        {
             return _repository.GetAllKoiOrderCustomers();
        }


        public bool UpdateKoiOrderCustomer(KoiOrderCustomer account)
        {
            return _repository.UpdateKoiOrderCustomer(account);
        }
    }

}

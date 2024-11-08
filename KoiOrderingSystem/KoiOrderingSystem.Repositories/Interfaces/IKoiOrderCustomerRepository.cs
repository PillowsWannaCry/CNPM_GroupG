using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiOrderingSystem.Repositories.Entities;

namespace KoiOrderingSystem.Repositories.Interfaces
{
    public interface IKoiOrderCustomerRepository
    {
        Task<List<KoiOrderCustomer>> GetAllKoiOrderCustomers();
        Boolean DelKoiOrderCustomer(int Id);
        Boolean DelKoiOrderCustomer(KoiOrderCustomer account);
        Boolean AddKoiOrderCustomer(KoiOrderCustomer account);
        Boolean UpdateKoiOrderCustomer(KoiOrderCustomer account);
        Task<KoiOrderCustomer> GetKoiOrderCustomerById(int Id);

    }
}

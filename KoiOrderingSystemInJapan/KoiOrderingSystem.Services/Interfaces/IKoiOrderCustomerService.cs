
using KoiOrderingSystem.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem.Services.Interfaces
{
    public interface IKoiOrderCustomerService
    {
        Task<List<KoiOrderCustomer>> KoiOrderCustomers();
        Boolean DelKoiOrderCustomer(int Id);
        Boolean DelKoiOrderCustomer(KoiOrderCustomer account);
        Task<bool> AddKoiOrderCustomer(KoiOrderCustomer account);
        Boolean UpdateKoiOrderCustomer(KoiOrderCustomer account);
        Task<KoiOrderCustomer> GetKoiOrderCustomerById(int Id);

    }
}

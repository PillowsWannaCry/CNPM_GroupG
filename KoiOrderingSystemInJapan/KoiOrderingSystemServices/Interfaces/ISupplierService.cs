using System.Collections.Generic;
using System.Threading.Tasks;
using KoiOrderingSystem.Repositories.Entities;

namespace KoiOrderingSystem.Services.Interfaces
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> GetAllSuppliersAsync();
        Task<Supplier?> GetSupplierByIdAsync(int supplierId);
        Task<bool> AddSupplierAsync(Supplier supplier);
        Task<bool> UpdateSupplierAsync(Supplier supplier);
        Task<bool> DeleteSupplierAsync(int supplierId);
        Task SaveChangesAsync();
    }
}

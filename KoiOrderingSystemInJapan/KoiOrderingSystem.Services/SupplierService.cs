using System.Collections.Generic;
using System.Threading.Tasks;
using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Repositories.Interfaces;
using KoiOrderingSystem.Services.Interfaces;

namespace KoiOrderingSystem.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync()
        {
            return await _supplierRepository.GetAllSuppliersAsync();
        }

        public async Task<Supplier?> GetSupplierByIdAsync(int supplierId)
        {
            return await _supplierRepository.GetSupplierByIdAsync(supplierId);
        }

        public async Task<bool> AddSupplierAsync(Supplier supplier)
        {
            return await _supplierRepository.AddSupplierAsync(supplier);
        }

        public async Task<bool> UpdateSupplierAsync(Supplier supplier)
        {
            return await _supplierRepository.UpdateSupplierAsync(supplier);
        }

        public async Task<bool> DeleteSupplierAsync(int supplierId)
        {
            return await _supplierRepository.DeleteSupplierAsync(supplierId);
        }

        public async Task SaveChangesAsync()
        {
            await _supplierRepository.SaveChangesAsync();
        }
    }
}

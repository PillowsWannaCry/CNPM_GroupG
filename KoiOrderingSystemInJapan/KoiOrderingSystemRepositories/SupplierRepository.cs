using System.Collections.Generic;
using System.Threading.Tasks;
using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KoiOrderingSystem.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly KoiOrderingSystemContext _context;

        public SupplierRepository(KoiOrderingSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Supplier?> GetSupplierByIdAsync(int supplierId)
        {
            return await _context.Suppliers.FindAsync(supplierId);
        }

        public async Task<bool> AddSupplierAsync(Supplier supplier)
        {
            await _context.Suppliers.AddAsync(supplier);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateSupplierAsync(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteSupplierAsync(int supplierId)
        {
            var supplier = await _context.Suppliers.FindAsync(supplierId);
            if (supplier == null) return false;
            _context.Suppliers.Remove(supplier);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

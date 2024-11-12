using System.Collections.Generic;
using System.Threading.Tasks;
using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KoiOrderingSystem.Repositories
{
    public class KoiOrderEmployeeRepository : IKoiOrderEmployeeRepository
    {
        private readonly KoiOrderingSystemContext _context;

        public KoiOrderEmployeeRepository(KoiOrderingSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<KoiOrderEmployee>> GetAllEmployeesAsync()
        {
            return await _context.KoiOrderEmployees.ToListAsync();
        }

        public async Task<KoiOrderEmployee?> GetEmployeeByIdAsync(int employeeId)
        {
            return await _context.KoiOrderEmployees.FindAsync(employeeId);
        }

        public async Task<bool> AddEmployeeAsync(KoiOrderEmployee employee)
        {
            await _context.KoiOrderEmployees.AddAsync(employee);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateEmployeeAsync(KoiOrderEmployee employee)
        {
            _context.KoiOrderEmployees.Update(employee);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteEmployeeAsync(int employeeId)
        {
            var employee = await _context.KoiOrderEmployees.FindAsync(employeeId);
            if (employee == null) return false;
            _context.KoiOrderEmployees.Remove(employee);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace KoiOrderingSystem.Repositories
{
    public class KoiOrderEmployeeRepository : IKoiOrderEmployeeRepository
    {
        private readonly KoiOrderingSystemContext _context;

        public KoiOrderEmployeeRepository(KoiOrderingSystemContext context)
        {
            _context = context;
        }

        public async Task<bool> AddKoiOrderEmployee(KoiOrderEmployee account)
        {
            try
            {
                _context.KoiOrderEmployees.Add(account);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateKoiOrderEmployee(KoiOrderEmployee account)
        {
            try
            {
                _context.KoiOrderEmployees.Update(account);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DelKoiOrderEmployee(int Id)
        {
            try
            {
                var employee = await _context.KoiOrderEmployees.FindAsync(Id);
                if (employee == null)
                {
                    return false;
                }

                _context.KoiOrderEmployees.Remove(employee);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DelKoiOrderEmployee(KoiOrderEmployee account)
        {
            try
            {
                _context.KoiOrderEmployees.Remove(account);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<KoiOrderEmployee> GetKoiOrderEmployeeById(int Id)
        {
            return await _context.KoiOrderEmployees
                .Include(e => e.Role)  
                .FirstOrDefaultAsync(e => e.EmployeeId == Id);
        }

        public IQueryable<KoiOrderEmployee> GetAllKoiOrderEmployees()
        {
            return _context.KoiOrderEmployees.AsQueryable();
        }

        
        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public async Task<bool> EmployeeExistsAsync(int id)
        {
            return await _context.KoiOrderEmployees.AnyAsync(e => e.EmployeeId == id);  
        }
    }
}

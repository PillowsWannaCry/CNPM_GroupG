using System.Collections.Generic;
using System.Threading.Tasks;
using KoiOrderingSystem.Repositories.Entities;

namespace KoiOrderingSystem.Repositories.Interfaces
{
    public interface IKoiOrderEmployeeRepository
    {
        IQueryable<KoiOrderEmployee> GetAllKoiOrderEmployees();
        Task<KoiOrderEmployee?> GetEmployeeByIdAsync(int employeeId);
        Task<bool> AddEmployeeAsync(KoiOrderEmployee employee);
        Task<bool> UpdateEmployeeAsync(KoiOrderEmployee employee);
        Task<bool> DeleteEmployeeAsync(int employeeId);
        Task SaveChangesAsync();
        Task<bool> EmployeeExistsAsync(int id);

    }
}

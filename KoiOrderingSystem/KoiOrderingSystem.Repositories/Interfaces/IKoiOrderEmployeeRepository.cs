using KoiOrderingSystem.Repositories.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace KoiOrderingSystem.Repositories.Interfaces
{
    public interface IKoiOrderEmployeeRepository
    {
        Task<bool> AddKoiOrderEmployee(KoiOrderEmployee account);
        Task<bool> UpdateKoiOrderEmployee(KoiOrderEmployee account);
        Task<bool> DelKoiOrderEmployee(int Id);
        Task<bool> DelKoiOrderEmployee(KoiOrderEmployee account);
        Task<KoiOrderEmployee> GetKoiOrderEmployeeById(int Id);
        IQueryable<KoiOrderEmployee> GetAllKoiOrderEmployees();
        Task<int> SaveChangesAsync();

        Task<bool> EmployeeExistsAsync(int id);
    }
}

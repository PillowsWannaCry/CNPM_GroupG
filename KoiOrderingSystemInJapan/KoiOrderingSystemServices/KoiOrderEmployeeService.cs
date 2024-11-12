using System.Collections.Generic;
using System.Threading.Tasks;
using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Repositories.Interfaces;
using KoiOrderingSystem.Services.Interfaces;

namespace KoiOrderingSystem.Services
{
    public class KoiOrderEmployeeService : IKoiOrderEmployeeService
    {
        private readonly IKoiOrderEmployeeRepository _employeeRepository;

        public KoiOrderEmployeeService(IKoiOrderEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<KoiOrderEmployee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllEmployeesAsync();
        }

        public async Task<KoiOrderEmployee?> GetEmployeeByIdAsync(int employeeId)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(employeeId);
        }

        public async Task<bool> AddEmployeeAsync(KoiOrderEmployee employee)
        {
            return await _employeeRepository.AddEmployeeAsync(employee);
        }

        public async Task<bool> UpdateEmployeeAsync(KoiOrderEmployee employee)
        {
            return await _employeeRepository.UpdateEmployeeAsync(employee);
        }

        public async Task<bool> DeleteEmployeeAsync(int employeeId)
        {
            return await _employeeRepository.DeleteEmployeeAsync(employeeId);
        }

        public async Task SaveChangesAsync()
        {
            await _employeeRepository.SaveChangesAsync();
        }
    }
}

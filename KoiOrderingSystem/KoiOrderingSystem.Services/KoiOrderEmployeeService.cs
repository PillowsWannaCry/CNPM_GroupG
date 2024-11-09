using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Repositories.Interfaces;
using KoiOrderingSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace KoiOrderingSystem.Services
{
    public class KoiOrderEmployeeService : IKoiOrderEmployeeService
    {
        private readonly IKoiOrderEmployeeRepository _repository;

        public KoiOrderEmployeeService(IKoiOrderEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddKoiOrderEmployee(KoiOrderEmployee account)
        {
            return await _repository.AddKoiOrderEmployee(account);
        }

        public async Task<bool> DelKoiOrderEmployee(int Id)
        {
            return await _repository.DelKoiOrderEmployee(Id);
        }

        public async Task<bool> DelKoiOrderEmployee(KoiOrderEmployee account)
        {
            return await _repository.DelKoiOrderEmployee(account);
        }

        public async Task<KoiOrderEmployee> GetKoiOrderEmployeeById(int Id)
        {
            return await _repository.GetKoiOrderEmployeeById(Id);
        }

        public IQueryable<KoiOrderEmployee> KoiOrderEmployees()
        {
            return _repository.GetAllKoiOrderEmployees();
        }
        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                
                var result = await _repository.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> UpdateKoiOrderEmployee(KoiOrderEmployee account)
        {
            return await _repository.UpdateKoiOrderEmployee(account);
        }

        public async Task<bool> EmployeeExistsAsync(int id)
        {
            return await _repository.EmployeeExistsAsync(id);  
        }
    }
}

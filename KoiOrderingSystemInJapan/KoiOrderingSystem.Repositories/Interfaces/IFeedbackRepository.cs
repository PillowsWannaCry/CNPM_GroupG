using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace KoiOrderingSystem.Repositories.Interfaces
{
    public interface IFeedbackRepository
    {
        IQueryable<Feedback> GetAllFeedbacks();
        Task<IEnumerable<Feedback>> GetFeedbacksByCustomerIdAsync(int customerId);
        Task AddFeedbackAsync(Feedback feedback);
        Task<bool> UpdateFeedbackAsync(Feedback feedback);
        Task DeleteFeedbackAsync(int feedbackId);
        Task<Feedback> GetFeedbackById(int id);
    }
}

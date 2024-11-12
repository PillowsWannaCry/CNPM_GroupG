using System.Collections.Generic;
using System.Threading.Tasks;
using KoiOrderingSystem.Repositories.Entities;

namespace KoiOrderingSystem.Services.Interfaces
{
    public interface IFeedbackService
    {
        Task<IEnumerable<Feedback>> GetFeedbacksByCustomerIdAsync(int customerId);
        Task AddFeedbackAsync(Feedback feedback);
        Task<bool> UpdateFeedbackAsync(Feedback feedback);
        Task DeleteFeedbackAsync(int feedbackId);
    }
}

using Joyeria.Domain.Entities;

namespace Joyeria.Application.Interfaces.Services
{
    public interface IComplaintService
    {
        Task<IEnumerable<Complaint>> GetComplaintsAsync();
        Task<Complaint> GetComplaintstByIdAsync(int id);
        Task<Complaint> CreateAsync(Complaint createToComplaints);
        Task<Complaint> UpdateAsync(Complaint complaintToUpdate);
        Task DeleteAsync(int id);
    }
}

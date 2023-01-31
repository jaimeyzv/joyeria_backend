using Joyeria.Domain.Entities;

namespace Joyeria.Application.UseCase.ComplaintUC.Commands
{
    public interface IComplaintCommands
    {
        Task<ComplaintModel> CreateAsync(ComplaintModel createToComplaints);
        Task<ComplaintModel> UpdateAsync(ComplaintModel complaintToUpdate);
        Task DeleteAsync(int id);
    }
}

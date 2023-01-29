using Joyeria.Application.Interfaces;
using Joyeria.Application.Interfaces.Services;
using Joyeria.Domain.Entities;

namespace Joyeria.Infrastructure.Services
{
    public class ComplaintService : IComplaintService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ComplaintService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Complaint> CreateAsync(Complaint createToComplaints)

        {
            await _unitOfWork.Complaint.CreateAsync(createToComplaints);
            await _unitOfWork.SaveChangesAsync();
            return createToComplaints;
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Complaint.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Complaint>> GetComplaintsAsync()
        {
            return await _unitOfWork.Complaint.GetComplaintsAsync();
        }

        public async Task<Complaint> GetComplaintstByIdAsync(int id)
        {
            return await _unitOfWork.Complaint.GetComplaintstByIdAsync(id);
        }

        public async Task<Complaint> UpdateAsync(Complaint complaintToUpdate)
        {
            await _unitOfWork.Complaint.UpdateAsync(complaintToUpdate);
            await _unitOfWork.SaveChangesAsync();

            return complaintToUpdate;
        }
    }
}

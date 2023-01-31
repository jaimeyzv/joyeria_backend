using AutoMapper;
using Joyeria.Application.Interfaces;
using Joyeria.Domain.Entities;
using System.Runtime.InteropServices;

namespace Joyeria.Application.UseCase.ComplaintUC.Commands
{
    public class ComplaintCommands : IComplaintCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ComplaintCommands(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ComplaintModel> CreateAsync(ComplaintModel createToComplaints)
        {
            var domain = _mapper.Map<Complaint>(createToComplaints);
            await _unitOfWork.Complaint.CreateAsync(domain);
            await _unitOfWork.SaveChangesAsync();
            return createToComplaints;

        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Complaint.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ComplaintModel> UpdateAsync(ComplaintModel complaintToUpdate)
        {
            var domain = _mapper.Map<Complaint>(complaintToUpdate);
            await _unitOfWork.Complaint.UpdateAsync(domain);
            await _unitOfWork.SaveChangesAsync();
            return complaintToUpdate;

        }
    }
}

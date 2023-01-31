using AutoMapper;
using Joyeria.Application.Interfaces;
using Joyeria.Application.UseCase.ComplaintUC.Commands;

namespace Joyeria.Application.UseCase.ComplaintUC.Queries
{
    public class ComplaintQueries : IComplaintQueries
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ComplaintQueries(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ComplaintModel>> GetComplaintsAsync()
        {
            var complaint = await _unitOfWork.Complaint.GetComplaintsAsync();
            var model = _mapper.Map<IEnumerable<ComplaintModel>>(complaint);
            return model;
        }

        public async Task<ComplaintModel> GetComplaintstByIdAsync(int id)
        {
            var categories = await _unitOfWork.Complaint.GetComplaintstByIdAsync(id);
            var model = _mapper.Map<ComplaintModel>(categories);
            return model;
        }
    }
}

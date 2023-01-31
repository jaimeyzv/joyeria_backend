using Joyeria.Application.UseCase.ComplaintUC.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joyeria.Application.UseCase.ComplaintUC.Queries
{
    public interface IComplaintQueries
    {
        Task<IEnumerable<ComplaintModel>> GetComplaintsAsync();
        Task<ComplaintModel> GetComplaintstByIdAsync(int id);
    }
}

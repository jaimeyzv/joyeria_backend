using AutoMapper;
using Joyeria.Application.UseCase.ComplaintUC.Commands;
using Joyeria.Application.UseCase.ComplaintUC.Queries;
using Joyeria.Application.ViewModels;
using Joyeria.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Joyeria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintController : ControllerBase
    {
        private readonly IComplaintCommands _complaintCommands;
        private readonly IComplaintQueries _complaintQueries;
        private readonly IMapper _mapper;

        public ComplaintController(IComplaintCommands complaintCommands,
            IComplaintQueries complaintQueries,
            IMapper mapper)
        {
            _complaintCommands = complaintCommands;
            _complaintQueries = complaintQueries;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetComplaints()
        {
            try
            {
                var complaint = await _complaintQueries.GetComplaintsAsync();
                return Ok(complaint);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetComplaintsById([FromRoute] int id)
        {
            try
            {
                var product = await _complaintQueries.GetComplaintstByIdAsync(id);
                if (product == null) return BadRequest($"Hoja de Reclamacion con id {id} no existe");

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }



        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ComplaintVM complaint)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest($"  Hoja de Reclamacion  no es valido");


                var model = _mapper.Map<ComplaintModel>(complaint);
                var complaintCreated = await _complaintCommands.CreateAsync(model);

                return Ok(complaintCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            try
            {
                var product = await _complaintQueries.GetComplaintstByIdAsync(id);
                if (product == null) return BadRequest($"Hoja de Reclamacion  con id {id} no existe");
                await _complaintCommands.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromBody] ComplaintVM complaint, [FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest($"Payload  Estado no es valido");

                var complaintFound = await _complaintQueries.GetComplaintstByIdAsync(id);
                if (complaintFound == null) return BadRequest($"Complaint con id {id} no existe");
                
                complaintFound.StatusC = complaint.StatusC;
             
               var complaintUpdated = await _complaintCommands.UpdateAsync(complaintFound);

                return Ok(complaintUpdated);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }






    }
}

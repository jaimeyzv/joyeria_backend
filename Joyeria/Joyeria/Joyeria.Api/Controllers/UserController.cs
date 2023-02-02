using AutoMapper;
using Joyeria.Application.UseCase.UserUC.Commands;
using Joyeria.Application.UseCase.UserUC.Queries;
using Joyeria.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Joyeria.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly IUserCommands _userCommands;
        private readonly IUserQueries _userQueries;
        private readonly IMapper _mapper;

        public UserController(IUserCommands userCommands, 
            IUserQueries userQueries, IMapper mapper)
        {
            _userCommands = userCommands;
            _userQueries = userQueries;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async   Task<IActionResult> GetUsers() 
        {
            try
            {
                var users = await _userQueries.GetUsersAsync();
                return Ok(users);
            }
            catch(Exception ex) {
                return BadRequest(new { message = ex.Message });
            }
        }
        [Route("{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetUserById([FromRoute]int id)
        {
            try
            {
                var user = await _userQueries.GetUserByIdAsync(id);
                if (user == null) return BadRequest($"Usuario con id{id} no existe");
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
  
        
        [HttpPost]
        public async  Task<IActionResult> Create([FromBody] UserVM user)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest($"Usuario no valido");
                //var userToCreate = new User()
                //{
                //    Name = user.Name,
                //    LastName = user.LastName,
                //    DocumentNumber = user.DocumentNumber,
                //    Email = user.Email,
                //    Password = user.Password,
                //    Address = user.Address,
                //    Cellphone = user.Cellphone,
                //    UserTypeId = user.UserTypeId,
                //    DocumentTypeId = user.DocumentTypeId
                //};

                var userToCreate = _mapper.Map<UserModel>(user);
                var userCreated = await _userCommands.CreateAsync(userToCreate);
                return Ok(userCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromBody] UserVM user, [FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest($" user no es valido");
                var userFound = await _userQueries.GetUserByIdAsync(id);
                if (userFound == null) return BadRequest($"user no es valido");
                //if(user.Name !=null)
                //userFound.Name = user.Name;
                //if (user.LastName != null)
                //userFound.LastName = user.LastName;
                //if(user.Address !=null)
                //userFound.Address = user.Address;
                //if (user.Cellphone != null)
                //userFound.Cellphone = user.Cellphone;
                //if (user.DocumentTypeId != 0)
                //userFound.DocumentTypeId = user.DocumentTypeId;
                //if(user.DocumentNumber !=null)
                //userFound.DocumentNumber = user.DocumentNumber;
                //if (user.Password != null)
                //userFound.Password = user.Password;

                var model = _mapper.Map<UserModel>(user);
                var userUpdated = await _userCommands.UpdateAsync(model);
                return Ok(userUpdated);
               
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });

            }
        }
    }
}

/*using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using HrSystem.API.RequestModels;
using HrSystem.Core.DTOs;
using HrSystem.Core.Interfaces.Managers;
using HrSystem.Core.Models;
using HrSystem.Core.Utilities;
using System.Threading.Tasks;
using HrSystem.Data.Entities;
using HrSystem.Core.DTOs;

namespace HrSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {

        private readonly IRoleManager roleManager;

        public RolesController(IRoleManager roleManager)
        {

            this.roleManager = roleManager;
        }



        [HttpGet()]
        public async Task<IActionResult> GetRoles()
        {
            var result = await roleManager.GetRoles();
            return Ok(new ResponseModel<object>
            {
                RequestSuccessful = true,
                ResponseCode = ResponseCodes.Successful,
                ResponseData = result
            });
        }




        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetRole(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return BadRequest(ResponseModel<string>.Failed("", "User is required"));

            UserRoleDto[] result = await roleManager.GetCurrentUserRole(userId);
            return Ok(ResponseModel<UserRoleDto[]>.IsSuccessful(result, "Successful"));
        }

        [HttpGet("paginated")]
        public async Task<IActionResult> GetRole(int pageSize = 20, int pageNumber = 1)
        {
            Page<RoleDto> result = await roleManager.GetRolePaginated(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] RoleVm model)
        {
            model.Validate();

            RoleDto role = new RoleDto().Assign(model);

            role = await roleManager.Create(role);
            return Ok(ResponseModel<RoleDto>.IsSuccessful(role, "Successful"));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateRole([FromBody] RoleVm model, long Id)
        {
            model.Validate();

            if (Id <= default(long))
                return BadRequest(ResponseModel<string>.Failed("", "Role is required"));

            RoleDto role = new RoleDto().Assign(model);
            role.Id = Id;

            role = await roleManager.UpdateRole(role);

            return Ok(ResponseModel<RoleDto>.IsSuccessful(role, "Successful"));
        }

        [HttpPut("{Id}/activate")]
        public async Task<IActionResult> Activate(long Id)
        {
            if (Id <= default(long))
                return BadRequest(ResponseModel<string>.Failed("", "Role is required"));

            RoleDto role = await roleManager.Activate(Id);
            return Ok(ResponseModel<RoleDto>.IsSuccessful(role, "Successful"));
        }

        [HttpPut("{Id}/deactivate")]
        public async Task<IActionResult> Deactivate(long Id)
        {
            if (Id <= default(long))
                return BadRequest(ResponseModel<string>.Failed("", "Role is required"));

            RoleDto role = await roleManager.Deactivate(Id);
            return Ok(ResponseModel<RoleDto>.IsSuccessful(role, "Successful"));
        }


    }
}*/
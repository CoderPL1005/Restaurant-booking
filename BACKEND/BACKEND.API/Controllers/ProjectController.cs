using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BACKEND.Model.Entities;
using BACKEND.Repo.GenericEntity;
using BACKEND.Model.DTO;
using BACKEND.Model.Common;
using BACKEND.API.Helpers;

namespace BACKEND.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        #region khai báo biến

        #region Phuc

        UsersRepo userRepo = new UsersRepo();
        #endregion

        #region Vinh
        #endregion

        #region Hung
        #endregion

        #region Duoc
        #endregion

        #region Hoi
        #endregion

        #endregion

        #region API get

        #region Phuc

        [HttpGet("getuser")]
        public async Task<IActionResult> getuser()
        {
            try
            {
                List<Users> user = userRepo.GetAll().Where(u => u.IsDeleted == false).ToList();

                return Ok(ApiResponseFactory.Success(user));
            }
            catch(Exception ex)
            {
                return BadRequest(ApiResponseFactory.Fail(ex, ex.Message));
            }
        }

        [HttpGet("getmenu")]
        public async Task<IActionResult> getmenu()
        {
            try
            {
                var menu = SQLHelper<object>.ProcedureToList("sp_GetMenuTree", new string[] { }, new object[] { });
                return Ok(ApiResponseFactory.Success(menu.FirstOrDefault()));
            }
            catch(Exception ex)
            {
                return BadRequest(ApiResponseFactory.Fail(ex, ex.Message));
            }
        }
        #endregion

        #region Vinh
        #endregion

        #region Hung
        #endregion

        #region Duoc
        #endregion

        #region Hoi
        #endregion

        #endregion

        #region API post

        #region Phuc

        [HttpPost("saveuser")]
        public async Task<IActionResult> saveuser([FromBody] UserDTO userDTO)
        {
            try
            {
                //update
                if(userDTO.UserId > 0)
                {
                    Users user = userRepo.GetByID(userDTO.UserId);

                    //delete
                    if(userDTO.IsDeleted == true)
                    {
                        user.IsDeleted = true;
                        userRepo.Update(user);
                        return Ok(ApiResponseFactory.Success("Deleted successfully!"));
                    }
                    if (user == null)
                    {
                        return NotFound(ApiResponseFactory.Fail(null, "User not found!"));
                    }

                    //cập nhật thông tin
                    user.Username = userDTO.Username;
                    user.PasswordHash = PasswordHasher.HashPassword(userDTO.PasswordHash);

                    userRepo.Update(user);
                }
                //create
                else 
                {
                    Users user = new Users
                    {
                        Username = userDTO.Username,
                        PasswordHash = PasswordHasher.HashPassword(userDTO.PasswordHash)
                    };

                    userRepo.Create(user);
                }

                return Ok(ApiResponseFactory.Success("Saved successfully!"));
            }
            catch(Exception ex)
            {
                return BadRequest(ApiResponseFactory.Fail(ex, ex.Message));
            }
        }
        #endregion

        #region Vinh
        #endregion

        #region Hung
        #endregion

        #region Duoc
        #endregion

        #region Hoi
        #endregion

        #endregion
    }
}

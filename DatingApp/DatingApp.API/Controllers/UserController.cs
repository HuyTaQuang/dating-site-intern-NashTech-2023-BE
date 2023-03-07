using DatingApp.BAL.Contacts;
using DatingApp.DAL.Contacts;
using DatingApp.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : BaseController<User>
    {
        // Kết nối qua interface 
        IUserRepository _userRepository;
        //IUserService _userService;

        //Injection
        public UserController(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var records = _userRepository.GetAllUsers();
                if (records != null)
                {
                    return StatusCode(StatusCodes.Status200OK, records);
                }
                else
                    return StatusCode(StatusCodes.Status404NotFound, "Không có bản ghi");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "Lỗi chưa xác định");
            }
        }

        /// <summary>
        /// Lấy thông tin ng dùng theo id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetUserById([FromRoute] int userId)
        {
            try
            {
                var records = _userRepository.GetUserById(userId);
                if (records != null)
                {
                    return StatusCode(StatusCodes.Status200OK, records);
                }
                else
                    return StatusCode(StatusCodes.Status404NotFound, "Không có bản ghi");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "Lỗi chưa xác định");
            }
        }

        /// <summary>
        /// Thêm mới người dùng
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/user")]
        public IActionResult InsertUser([FromBody] User user)
        {
            try
            {
                // Xử lý dữ liệu check mã bị trùng


                // Thêm mới thành công vào db
                var success = _userRepository.InsertUser(user);
                if (success)
                {
                    return StatusCode(StatusCodes.Status200OK, success);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Không có bản ghi");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "Lỗi chưa xác định");
            }
        }

        /// <summary>
        /// Chỉnh sửa người dùng theo id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{userId}")]
        public IActionResult UpdateUserById([FromBody] User user, int userId)
        {
            try
            {
                var users = _userRepository.UpdateUserById(user, userId);
                if (users)
                {
                    return StatusCode(StatusCodes.Status200OK, users);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Không có bản ghi");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{userId}")]
        public IActionResult DeleteUserById(int userId)
        {
            try
            {
                var check = _userRepository.DeleteUserById(userId);
                if (check == 1)
                {
                    return StatusCode(StatusCodes.Status200OK, new OkObjectResult(new
                    {
                        message = "Delete user success",
                        data = check,
                    }));

                }
                else if (check == 0)
                {
                    return StatusCode(StatusCodes.Status200OK, new OkObjectResult(new
                    {
                        message = "Delete user success",
                        data = check,
                    }));
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Lỗi chưa xác định");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "Lỗi chưa xác định");
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("/v1/login-user")]
        public IActionResult Validate(LoginModel model)
        {
            try
            {
                var check = _userRepository.Validate(model);
                if (check != null)
                {
                    return StatusCode(StatusCodes.Status200OK, new OkObjectResult(new
                    {
                        message = "Authentication success",
                        data = check,
                    }));

                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Ivalid username/password");
                }                   
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "Lỗi chưa xác định");
            }
        }



        //[HttpPost("register-user")]
        //public async Task<ActionResult<User>> Register(RegisterModel model)
        //{
        //    try
        //    {
        //        var records = _userRepository.Register(model);
        //        if (records != null)
        //        {
        //            return StatusCode(StatusCodes.Status200OK, "Đăng ký thành công");
        //        }
        //        else
        //            return StatusCode(StatusCodes.Status404NotFound, "Đăng ký không thành công");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return StatusCode(StatusCodes.Status400BadRequest, "Lỗi chưa xác định");
        //    }
        //}
        }
}

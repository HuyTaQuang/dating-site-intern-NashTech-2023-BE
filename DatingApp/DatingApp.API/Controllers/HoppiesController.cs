using DatingApp.DAL.Contacts;
using DatingApp.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HoppiesController : BaseController<Hobby>
    {
        IHobbyRepository _hoppyRepository;

        public HoppiesController(IHobbyRepository hobbyRepository) : base(hobbyRepository)
        {
            _hoppyRepository = hobbyRepository;
        }

        [HttpGet]
        public IActionResult GetAllHobbies()
        {
            try
            {
                var hobbies = _hoppyRepository.GetAllHobbies();
                if (hobbies != null)
                {
                    return StatusCode(StatusCodes.Status200OK, hobbies);
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
        /// Lấy hobby theo id
        /// </summary>
        /// <param name="hobbyId"></param>
        /// <returns>Bản ghi hobby</returns>
        [HttpGet]
        [Route("{hobbyId}")]
        public IActionResult GetRecordById([FromRoute] int hobbyId)
        {
            try
            {
                var records = _hoppyRepository.GetHobbyById(hobbyId);
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
        /// Thêm mới hobby
        /// </summary>
        /// <param name="hobby"></param>
        /// <returns>Trả về 1 nếu thêm mới thành công</returns>
        /// <returns>Trả về 0 nếu thêm mới không thành công</returns>
        [HttpPost]
        [Route("/hobby")]
        public IActionResult InsertUser([FromBody] Hobby hobby)
        {
            try
            {
                // Xử lý dữ liệu check mã bị trùng


                // Thêm mới thành công vào db
                var success = _hoppyRepository.InsertHobby(hobby);
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
        /// Chỉnh sửa hobby theo id
        /// </summary>
        /// <param name="hobbyId"></param>
        /// <param name="hobby"></param>
        /// <returns>Trả về 1 nếu sửa thành công</returns>
        /// <returns>Trả về 0 nếu sửa không thành công</returns>
        [HttpPut]
        [Route("{hobbyId}")]
        public IActionResult UpdateHobbyById([FromBody] Hobby hobby, int hobbyId)
        {
            try
            {
                var users = _hoppyRepository.UpdateHobbyById(hobby, hobbyId);
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

        /// <summary>
        /// Xoá thông tin hobby theo id
        /// </summary>
        /// <param name="hobbyId"></param>
        /// <returns>Trả về 1 nếu sửa thành công</returns>
        /// <returns>Trả về 0 nếu sửa không thành công</returns>
        [HttpDelete]
        [Route("{hobbyId}")]
        public IActionResult DeleteHobbyById(int hobbyId)
        {
            try
            {
                var check = _hoppyRepository.DeleteHobbyById(hobbyId);
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
    }
}

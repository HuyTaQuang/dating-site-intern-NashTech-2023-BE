using DatingApp.DAL.Contacts;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        private readonly IBaseRepository<T> _baseRepository;

        public BaseController (IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        /// <summary>
        /// API lấy danh sách bản ghi
        /// </summary>
        /// <returns>Trả về danh sách toàn bộ bản ghi</returns>
        //[HttpGet]
        //public IActionResult GetAllRecords()
        //{
        //    try
        //    {
        //        var records = _baseRepository.GetAllRecords();
        //        if (records != null)
        //        {
        //            return StatusCode(StatusCodes.Status200OK, records);
        //        }
        //        else
        //            return StatusCode(StatusCodes.Status404NotFound, "Không có bản ghi");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return StatusCode(StatusCodes.Status400BadRequest, "Lỗi chưa xác định");
        //    }
        //}

        //[HttpGet]
        //[Route("{recordId}")]
        //public IActionResult GetRecordById([FromRoute] int recordId)
        //{
        //    try
        //    {
        //        var records = _baseRepository.GetRecordById(recordId);
        //        if (records != null)
        //        {
        //            return StatusCode(StatusCodes.Status200OK, records);
        //        }
        //        else
        //            return StatusCode(StatusCodes.Status404NotFound, "Không có bản ghi");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return StatusCode(StatusCodes.Status400BadRequest, "Lỗi chưa xác định");
        //    }
        //}

        /// <summary>
        /// API khởi tạo record mới 
        /// </summary>
        /// <param name="t"></param>
        /// <returns>Id của người record khởi tạo</returns>
        //[HttpPost]
        //[Route("/{t}")]
        //public IActionResult InsertUser([FromBody] T t)
        //{
        //    try
        //    {
        //        // Xử lý dữ liệu check mã bị trùng


        //        // Thêm mới thành công vào db
        //        var idUser = _baseRepository.InsertRecord(t);
        //        return StatusCode(StatusCodes.Status200OK, new OkObjectResult(new
        //        {
        //            message = "Authentication success",
        //            data = idUser,
        //        }));
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return StatusCode(StatusCodes.Status400BadRequest, "Lỗi chưa xác định");
        //    }
        //}

        ///// <summary>
        ///// API sửa người dùng theo id
        ///// </summary>
        ///// <param name="user"></param>
        ///// <param name="userId"></param>
        ///// <returns>Sẽ trả về id người dùng được sửa</returns>
        //[HttpPut]
        //[Route("{userId}")]
        //public IActionResult UpdateUserById([FromBody] User user, [FromRoute] Guid userId)
        //{
        //    try
        //    {
        //        var users = _userRepository.UpdateUserById(user, userId);
        //        return StatusCode(StatusCodes.Status200OK, user.UserID);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return StatusCode(StatusCodes.Status400BadRequest, "Lỗi chưa xác định");
        //    }
        //}

        //[HttpDelete("{userId}")]
        //public IActionResult DeleteUserById(Guid userId)
        //{
        //    try
        //    {
        //        var users = _userRepository.DeleteUserById(userId);
        //        return StatusCode(StatusCodes.Status200OK, "Xoá thành công!");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return StatusCode(StatusCodes.Status400BadRequest, "Lỗi chưa xác định");
        //    }
    }
}

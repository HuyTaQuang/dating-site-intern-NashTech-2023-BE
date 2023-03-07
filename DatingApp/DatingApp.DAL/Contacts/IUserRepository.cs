using DatingApp.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.DAL.Contacts
{
    public interface IUserRepository : IBaseRepository<User>
    {
        // Hàm đăng ký người dùng
        string Validate(LoginModel model);

        IEnumerable<User> Index();

        IEnumerable<User> GetAllUsers();

        /// <summary>
        /// Lấy người dùng theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetUserById(int userId);

        /// <summary>
        /// Thêm người dùng
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Người dùng vừa thêm</returns>
        bool InsertUser(User user);

        /// <summary>
        /// Chỉnh sửa người dùng theo id
        /// </summary>
        /// <param name="user"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        bool UpdateUserById(User user, int userId);

        /// <summary>
        /// Xoá người dùng theo id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        int DeleteUserById(int userId);



    }
}

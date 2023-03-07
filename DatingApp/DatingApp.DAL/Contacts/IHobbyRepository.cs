using DatingApp.DAL.Models;


namespace DatingApp.DAL.Contacts
{
    public interface IHobbyRepository : IBaseRepository<Hobby>
    {
        IEnumerable<Hobby> GetAllHobbies();

        /// <summary>
        /// Láy thông tin sở thích theo id
        /// </summary>
        /// <param name="hobbyId"></param>
        /// <returns>Thông tin sở thích</returns>
        Hobby GetHobbyById(int hobbyId);

        /// <summary>
        /// Thêm sở thích
        /// </summary>
        /// <param name="hobby"></param>
        /// <returns>Đúng nếu thêm mới thành công</returns>
        /// <returns>Sai nếu thêm mới không thành công</returns>
        bool InsertHobby(Hobby hobby);

        /// <summary>
        /// Chỉnh sửa sở thích theo id
        /// </summary>
        /// <param name="hobby"></param>
        /// <param name="hobbyId"></param>
        /// <returns>Đúng nếu thêm mới thành công</returns>
        /// <returns>Sai nếu thêm mới không thành công</returns>
        bool UpdateHobbyById(Hobby hobby, int hobbyId);

        /// <summary>
        /// Xoá sở thích theo id
        /// </summary>
        /// <param name="hobbyId"></param>
        /// <returns>1 nếu xoá thánh công</returns>
        /// <returns>0 nếu xoá thất bại</returns>
        int DeleteHobbyById(int hobbyId);
    }
}

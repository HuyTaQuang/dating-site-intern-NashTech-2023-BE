namespace DatingApp.DAL.Contacts
{
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Lấy danh sách người dùng
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAllRecords();

        ///// <summary>
        ///// Lấy người dùng theo id
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        T GetRecordById(int recordId);

        /// <summary>
        /// Thêm người dùng
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Người dùng vừa thêm</returns>
        int InsertRecord(T t);

        // <summary>
        // Chỉnh sửa người dùng theo id
        // </summary>
        // <param name = "user" ></ param >
        // < param name="userId"></param>
        // <returns></returns>
        int UpdateRecordById(T t, int recordId);

        // <summary>
        // Xoá người dùng theo id
        // </summary>
        // <param name = "userId" ></ param >
        // < returns ></ returns >
        int DeleteRecordById(T t, int recordId);
    }
}

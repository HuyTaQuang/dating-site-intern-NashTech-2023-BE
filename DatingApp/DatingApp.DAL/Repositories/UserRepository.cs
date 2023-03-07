using DatingApp.DAL.Contacts;
using DatingApp.DAL.Data;
using DatingApp.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DatingApp.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        #region
        private AppDbContext _context;
        private AppSetting _appSetting;
        #endregion

        public UserRepository(AppDbContext dbContext, IOptionsMonitor<AppSetting> optionsMonitor) : base(dbContext)
        {
            _context = dbContext;
            _appSetting = optionsMonitor.CurrentValue; // Lấy đúng giá trị
        }

        /// <summary>
        /// Hiển thị user khi IsDeleted is false
        /// </summary>
        /// <returns>Danh sách user</returns>
        public IEnumerable<User> Index()
        {
            try
            {
                var users = _context.Users.Where(x => x.IsDeleted == false).ToList();
                if (users != null)
                {
                    return users;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
                     
        }

        public IEnumerable<User> GetAllUsers()
        {
            try
            {
                //var dataList = _context.Users.ToList();
                var dataList = _context.Users.Where(x => x.IsDeleted == false).ToList();
                if (dataList != null)
                {
                    return dataList;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public User GetUserById(int userId)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(us => us.UserId == userId && us.IsDeleted == false);
                if (user != null)
                {
                    return user;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public bool InsertUser(User user)
        {
            try
            {
                // Xử lý tên ko đc để trống
                //if (string.IsNullOrEmpty(user.FullName))
                //    return BadRequst(new
                //    {
                //        ErrorCode = 501,
                //        ErrorMessage = "Invalid Empty Name",
                //    });

                // Xét id người dùng ko bị trùng và isdeleted phải là false
                //var newUser = _context.Users.Where(x => x.UserId == user.UserId && x.IsDeleted == false).SingleOrDefault();
                //if(newUser != null)
                //{
                //    return Conflict(new
                //    {
                //        ErrorCode = 502,
                //        ErrorMessage = "Id của bạn bị trùng ",
                //    });
                //}

                var dbTable = new List<User>
                {
                    new User {FullName="Hiếu",Password="123456"},
                    new User {FullName="Huy",Password="admin"},
                    new User {FullName="Trinh",Password="admin123456"},
                };

                //User dbTable = new User();                
                //dbTable.UserId = user.UserId;
                //dbTable.Username = user.Username;
                //dbTable.FullName = user.FullName;
                //dbTable.Email = user.Email;
                //dbTable.Avatar = user.Avatar;
                //dbTable.Address = user.Address;
                //dbTable.Gender = user.Gender;
                //dbTable.Date_Of_Birth = user.Date_Of_Birth;
                //dbTable.Description = user.Description;

                // Chuyển hướng đến csdl
                if (!_context.Users.Any()) //Ko có bản ghi nào trong csdl
                {
                    _context.Users.AddRange(dbTable);
                    _context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public bool UpdateUserById(User user, int userId)
        {
            var check = _context.Users.Where(us => us.UserId.Equals(userId)).SingleOrDefault();
            if (check != null)
            {
                check.Username = user.Username;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public int DeleteUserById(int userId)
        {
            try
            {
                var user = _context.Users.Where(us => us.UserId.Equals(userId)).SingleOrDefault();
                if (user != null)
                {
                    user.IsDeleted = true;
                    return 1;
                }
                
                else
                    return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        /// <summary>
        /// Hàm kiểm tra quyền truy cập
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Chuỗi khoá</returns>
        public string Validate(LoginModel model)
        {
            var user = _context.Users.SingleOrDefault(p => p.Username == model.Username 
                && model.Password == p.Password);
            if (user == null)
            {
                return null;
            }
            return GenerationToken(user);
        }

        /// <summary>
        /// Hàm dùng riêng cho lớp
        /// Config mã token
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Chuỗi ký tự mã </returns>
        private string GenerationToken(User user)
        {     
            var JwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSetting.SecretKey);
            var tokenDescription = new SecurityTokenDescriptor
            {
                // Quyền sở hữu
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.FullName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("UserName", user.Username),
                    new Claim("Id", user.UserId.ToString()),

                    //Roles

                    new Claim("TokenId",Guid.NewGuid().ToString()),
                }),

                // Time hết hạn là bao nhiều
                Expires = DateTime.UtcNow.AddMinutes(10),

                // Ký tá
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey
                (secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = JwtTokenHandler.CreateToken(tokenDescription);

            // Trả về một chuỗi
            return JwtTokenHandler.WriteToken(token);
        }    
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.DAL.Models
{
    /// <summary>
    /// Có thể thay đổi khoá bảo mật 
    /// Tự động map với appsetting 
    /// </summary>
    public class AppSetting
    {
        public string SecretKey { get; set; }
    }
}

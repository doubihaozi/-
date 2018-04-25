using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Customer
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public  string Password { get; set; }
        /// <summary>
        /// 登录账号
        /// </summary>
        public  string LoginName { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public  string UserName{get;set;}
    }
}

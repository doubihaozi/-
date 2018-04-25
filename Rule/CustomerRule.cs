using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rule
{
    public class CustomerRule
    {
        /// <summary>
        /// 方法：查询指定的用户名是否存在
        /// </summary>
        /// <param name="uid">用户名</param>
        /// <returns>是否存在</returns>
        public bool TestInsert(string uid)
        {
            return (int)DAL.SQLHelp.ExecScalar("select count(*) from [Customer] where [LoginName]='" + uid + "'") == 0;
        }
    }
}

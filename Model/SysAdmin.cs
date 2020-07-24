using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //管理员类
    [Serializable]
    public class SysAdmin
    {
        public int LoginId { get; set; }
        public string AdminName { get; set; }
        public string LoginPwd { get; set; }
    }
}

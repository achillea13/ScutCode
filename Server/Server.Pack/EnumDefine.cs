using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Pack
{
    public enum LoginError
    {
        LE_NOT_EXIST = 1,       // 不存在用户
        LE_PSD_ERROR,           // 密码错误
    }
}

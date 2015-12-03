using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Green.Health.Entity
{
    public enum LoginResult
    {
        /// <summary>
        /// 登陆成功
        /// </summary>
        Success,
        /// <summary>
        /// 用户不存在
        /// </summary>
        NotExist,
        /// <summary>
        /// 密码错误
        /// </summary>
        PwdError,
        /// <summary>
        /// 未激活
        /// </summary>
        IsNotActive
    }
}

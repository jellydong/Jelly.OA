using Jelly.OA.EFDAL;
using Jelly.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jelly.OA.BLL
{
    //模块内高内聚，模块间低耦合

    //变化点：1、跨数据库 2、数据库访问驱动层驱动变化
    public class UserInfoService
    {
        //这样直接创建，高耦合，不好
        UserInfoDal userInfoDal = new UserInfoDal();

        public UserInfo Add(UserInfo userinfo)
        {
            return userInfoDal.Add(userinfo);
        }
    }
}

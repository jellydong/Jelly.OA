using Jelly.OA.DALFactory;
using Jelly.OA.EFDAL;
using Jelly.OA.IDAL;
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
        //UserInfoDal userInfoDal = new UserInfoDal();

        //这样后面不管New什么，只要实现接口的方法就好了，下面的代码不受影响。
        //IUserInfoDal userInfoDal = new UserInfoDal();
        //依赖接口编程 依赖抽象编程。

        //如果我换了用Ado.Net那么这里的类名不是UserInfoDal了，那么很多地方引用，如果改变了，所有的地方都需要改。
        //希望改一个地方所有的地方都改了，那么就用到了工厂类
        IUserInfoDal userInfoDal = StaticDalFactory.GetUserInfoDal();
        public UserInfo Add(UserInfo userinfo)
        {
            return userInfoDal.Add(userinfo);
        }
    }
}

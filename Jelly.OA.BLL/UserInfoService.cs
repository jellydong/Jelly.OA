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
        //private IUserInfoDal userInfoDal = StaticDalFactory.GetUserInfoDal();

        private readonly IDbSession dbSession = DbSessionFactory.GetCurrentDbSession();

        //更高级的： Ioc、DI  依赖注入的方式。Spring.Net
        public UserInfo Add(UserInfo userinfo)//UnitWork单元工作模式。
        {
            //return userInfoDal.Add(userinfo);
            dbSession.UserInfoDal.Add(userinfo);
            if (dbSession.SaveChanges()>0)
            {
                //xxxxx
            }
            //dbSession.UserInfoDal.Add(new UserInfo());
            //上边注释，就是说可以多次操作一次提交
            dbSession.SaveChanges();//数据提交的权力从数据库访问层提到了业务逻辑层。
            //SaveChanges内部本身是有事务的
            return userinfo;
        }
    }
}

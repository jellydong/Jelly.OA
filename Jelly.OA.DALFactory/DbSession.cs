using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jelly.OA.EFDAL;
using Jelly.OA.IDAL;

namespace Jelly.OA.DALFactory
{
   public class DbSession:IDbSession
    {
        #region 简单工厂或者抽象工厂部分
        public IUserInfoDal UserInfoDal
        {
            get { return StaticDalFactory.GetUserInfoDal(); }
        }

        public IOrderInfoDal OrderInfoDal
        {
            get { return StaticDalFactory.GetOrderInfoDal(); }
        } 
        #endregion
        /// <summary>
        /// 拿到当前的EF上下文，然后进行  把修改实体进行一个整体提交。
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
           return DbContextFactory.GetCurrentDbContext().SaveChanges();
        }
    }
}

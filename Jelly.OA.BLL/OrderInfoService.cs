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
    public class OrderInfoService : BaseService<OrderInfo>
    {
        public override void SetCurrentDal()
        {
            CurrentDal = this.DbSession.OrderInfoDal;
        }
    }
}

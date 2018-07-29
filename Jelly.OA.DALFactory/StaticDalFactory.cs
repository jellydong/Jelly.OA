using Jelly.OA.EFDAL;
using Jelly.OA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jelly.OA.DALFactory
{
    public class StaticDalFactory
    {

        public static IUserInfoDal GetUserInfoDal()
        {
            return new UserInfoDal();
        }
    }
}

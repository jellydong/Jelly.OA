using Jelly.OA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jelly.OA.AdoDAL
{
    public class AdoUserInfoDal : IUserInfoDal
    {
        public OA.Model.UserInfo Add(OA.Model.UserInfo entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(OA.Model.UserInfo entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<OA.Model.UserInfo> GetEntities(System.Linq.Expressions.Expression<Func<OA.Model.UserInfo, bool>> whereLambda)
        {
            throw new NotImplementedException();
        }

        public IQueryable<OA.Model.UserInfo> GetPageEntities<S>(int pageSize, int pageIndex, out int total, System.Linq.Expressions.Expression<Func<OA.Model.UserInfo, bool>> whereLambda, System.Linq.Expressions.Expression<Func<OA.Model.UserInfo, S>> orderByLambda, bool isAsc)
        {
            throw new NotImplementedException();
        }

        public bool Update(OA.Model.UserInfo entity)
        {
            throw new NotImplementedException();
        }
    }
}

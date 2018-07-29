using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jelly.OA.IDAL
{
    public interface IBaseDal<T> where T : class, new()
    {
        #region 查询 
        IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda);

        //分页查询

        IQueryable<T> GetPageEntities<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc);

        #endregion

        #region crud
        T Add(T entity);

        bool Update(T entity);
        bool Delete(T entity);


        #endregion

    }
}

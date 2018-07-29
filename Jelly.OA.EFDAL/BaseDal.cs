using Jelly.OA.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jelly.OA.EFDAL
{
    /// <summary>
    /// 职责：封装所有Dal的公共的curd方法
    /// </summary>
    public class BaseDal<T> where T:class,new()
    {
        DataModelContainer db = new DataModelContainer();

        #region 查询

        #region 下面的Lambda表达式的可以代替这两个
        //public T GetTById(int id)
        //{ 
        //    //这里缺少一个引用，最后添加新建项EF生成器解决的
        //    return db.T.Find(id);
        //}

        //public List<T> GetAllTs()
        //{
        //    DataModelContainer db = new DataModelContainer();
        //    return db.T.ToList();
        //} 
        #endregion

        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {

            //条件是活的  根据用户传的来s
            return db.Set<T>().Where(whereLambda).AsQueryable();
        }

        //分页查询

        public IQueryable<T> GetPageEntities<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc)
        {
            total = db.Set<T>().Where(whereLambda).Count();
            if (isAsc)
            {
                var temp = db.Set<T>().Where(whereLambda)
                .OrderBy<T, S>(orderByLambda)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize).AsQueryable();
                return temp;
            }
            else
            {
                var temp = db.Set<T>().Where(whereLambda)
                .OrderByDescending<T, S>(orderByLambda)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize).AsQueryable();
                return temp;
            }
        }

        #endregion

        #region crud
        public T Add(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();
            return entity;
        }

        public bool Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public bool Delete(T entity)
        {
            db.Entry(entity).State = EntityState.Deleted;
            return db.SaveChanges() > 0;
        }


        #endregion
    }
}

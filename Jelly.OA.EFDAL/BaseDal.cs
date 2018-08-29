using Jelly.OA.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jelly.OA.EFDAL
{
    /// <summary>
    /// 职责：封装所有Dal的公共的curd方法
    /// 类的职责一定要单一
    /// </summary>
    public class BaseDal<T> where T : class, new()
    {
        // DataModelContainer db = new DataModelContainer();

        //依赖抽象编程
        //好处 可以应对变化的时候改变最小
        public DbContext Db
        {
            get
            {
                return DbContextFactory.GetCurrentDbContext();
            }
        }

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
            return Db.Set<T>().Where(whereLambda).AsQueryable();
        }

        //分页查询

        public IQueryable<T> GetPageEntities<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc)
        {
            total = Db.Set<T>().Where(whereLambda).Count();
            if (isAsc)
            {
                var temp = Db.Set<T>().Where(whereLambda)
                .OrderBy<T, S>(orderByLambda)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize).AsQueryable();
                return temp;
            }
            else
            {
                var temp = Db.Set<T>().Where(whereLambda)
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
            Db.Set<T>().Add(entity);
            //Db.SaveChanges();
            return entity;
        }

        public bool Update(T entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            //return Db.SaveChanges() > 0;
            return true;
        }
        public bool Delete(T entity)
        {
            Db.Entry(entity).State = EntityState.Deleted;
            //return Db.SaveChanges() > 0;
            return true;
        }


        #endregion
    }
}

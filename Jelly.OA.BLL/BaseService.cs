using System;
using System.Linq;
using System.Linq.Expressions;
using Jelly.OA.DALFactory;
using Jelly.OA.IDAL;

namespace Jelly.OA.BLL
{
    /// <summary>
    /// 父类要逼迫子类给父类一个属性赋值
    /// 赋值的操作必须在父类的方法调用之前先执行
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseService<T> where T : class, new()
    {
        public IBaseDal<T> CurrentDal { get; set; }
        public IDbSession DbSession
        {
            get
            {
               return DbSessionFactory.GetCurrentDbSession();
            }
        }
        public BaseService()//基类的构造函数
        {
            SetCurrentDal();//调用抽象方法
        }

        public abstract void SetCurrentDal();//抽象方法：要求子类必须实现。

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
            return CurrentDal.GetEntities(whereLambda);
        }

        //分页查询

        public IQueryable<T> GetPageEntities<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc)
        {
            #region old
            //total = Db.Set<T>().Where(whereLambda).Count();
            //if (isAsc)
            //{
            //    var temp = Db.Set<T>().Where(whereLambda)
            //    .OrderBy<T, S>(orderByLambda)
            //    .Skip(pageSize * (pageIndex - 1))
            //    .Take(pageSize).AsQueryable();
            //    return temp;
            //}
            //else
            //{
            //    var temp = Db.Set<T>().Where(whereLambda)
            //    .OrderByDescending<T, S>(orderByLambda)
            //    .Skip(pageSize * (pageIndex - 1))
            //    .Take(pageSize).AsQueryable();
            //    return temp;
            //} 
            #endregion

            return CurrentDal.GetPageEntities(pageSize, pageIndex, out total, whereLambda, orderByLambda, isAsc);
        }

        #endregion

        #region crud

        public T Add(T entity)
        {
             CurrentDal.Add(entity);
             DbSession.SaveChanges();
            return entity;
        }

        public bool Update(T entity)
        {
             CurrentDal.Update(entity);
            return DbSession.SaveChanges() > 0;
        }

        public bool Delete(T entity)
        {
             CurrentDal.Delete(entity);
            return DbSession.SaveChanges() > 0;
        }
        #endregion
    }
}
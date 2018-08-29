using System.Data.Entity;
using System.Runtime.Remoting.Messaging;
using Jelly.OA.IDAL;

namespace Jelly.OA.DALFactory
{
    public class DbSessionFactory
    {
        public static IDbSession GetCurrentDbSession()
        {
            //一次请求共用一个实列
            //返回值类型DbContext 上下文都可以切换
            //return new DataModelContainer();
            IDbSession db = CallContext.GetData("DbSession") as IDbSession;
            if (db == null)
            {
                db = new DbSession();
                CallContext.SetData("DbSession", db);
            }

            return db;
        }
    }
}
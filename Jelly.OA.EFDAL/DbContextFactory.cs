using Jelly.OA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jelly.OA.EFDAL
{
    public class DbContextFactory
    {
        public static DbContext GetCurrentDbContext()
        {
            //一次请求共用一个实列
            //返回值类型DbContext 上下文都可以切换
            return new DataModelContainer();
        }
    }
}

using Jelly.OA.EFDAL;
using Jelly.OA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Jelly.OA.DALFactory
{
    /// <summary>
    /// 由简单工厂转变成了抽象工厂
    /// 抽象工厂 vs 简单工厂
    /// 简单工厂还是依赖关系，还是需要改代码
    /// 抽象工厂改配置 
    /// </summary>
    public class StaticDalFactory
    {
        public static string assemblyName = System.Configuration.ConfigurationManager.AppSettings["DalAssemblyName"].ToString();

        public static IUserInfoDal GetUserInfoDal()
        {
            //return new UserInfoDal();
            //使用反射，new还是不好,把new去掉，改一个配置，那么创建实列就发生变化，不需要改代码
            //return Assembly.Load("Jelly.OA.EFDAL").CreateInstance("Jelly.OA.EFDAL.UserInfoDal") as IUserInfoDal;
            //改一个配置，那么创建实列就发生变化，不需要改代码
            //反射的方式 获取Dal实列，可以通过配置改变实例
            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".UserInfoDal") as IUserInfoDal;
        }

        public static IOrderInfoDal GetOrderInfoDal()
        {
            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".OrderInfoDal") as IOrderInfoDal;
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jelly.OA.EFDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jelly.OA.Model;

namespace Jelly.OA.EFDAL.UnitTests
{
    [TestClass()]
    public class UserInfoDalUnitTests
    {
        [TestMethod()]
        public void GetUsersUnitTest()
        {
            //测试获取数据的方法
            UserInfoDal dal = new UserInfoDal();
            //单元测试必须自己处理数据，不能依赖带伞房数据。如果依赖数据，那么先自己创建，然后用完之后清除。

            //创建测试的数据
            for (int i = 1; i <= 10; i++)
            {
                dal.Add(new UserInfo
                {
                    UName = "第" + i + "个"
                });
            }
            var temp = dal.GetEntities(u => u.UName.Contains("个"));

            //断言
            Assert.AreEqual(true, temp.Count() >= 10);
        } 
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace BusinessLogic.Tests
{
    [TestClass()]
    public class UniverServiceTests
    {
        UniverService<StudentDb> univerService;
        [TestMethod()]
        public void GetSeveralTest()
        {
            int[] ids = new [] {1, 2, 3 };
            var res = new List<StudentDb>();

            var resp = univerService.GetSeveral(ids);

            Assert.AreEqual(resp, res);
        }
    }
}
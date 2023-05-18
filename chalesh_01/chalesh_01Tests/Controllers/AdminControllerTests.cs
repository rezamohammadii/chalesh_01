using Microsoft.VisualStudio.TestTools.UnitTesting;
using chalesh_01.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chalesh_01.core.CodeFactory;
using Newtonsoft.Json.Linq;

namespace chalesh_01.Controllers.Tests
{
    [TestClass()]
    public class AdminControllerTests
    {
        [TestMethod()]
        public void HasPropertyTest_True()
        {
            JObject obj = new JObject();
            obj["message"] = "hi";
            var res = Utils.HasProperty(obj, "message");
            Assert.IsTrue(res);
        }

        [TestMethod()]
        public void HasPropertyTest_False()
        {
            JObject obj = new JObject();
            obj["message"] = "hi";
            var res = Utils.HasProperty(obj, "test");
            Assert.IsFalse(res);
        }

        [TestMethod()]
        public void HasPropertyTest_GetValue()
        {
            JObject obj = new JObject();
            obj["message"] = "hi";
            obj["test"] = "reza";
            var res = Utils.GetPropertyValue(obj, "message");
            Assert.IsNotNull(res);
        }
        [TestMethod()]
        public void HasPropertyTest_GetValue_Null()
        {
            JObject obj = new JObject();
            obj["message"] = "";
            obj["test"] = "reza";
            var res = Utils.GetPropertyValue(obj, "tr");
            Assert.IsNull(res);
        }
    }
}
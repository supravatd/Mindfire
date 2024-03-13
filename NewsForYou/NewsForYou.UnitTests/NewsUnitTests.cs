using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsForYou.Web.Controllers;
using System;
using static NewsForYou.Model.Model;

namespace NewsForYou.UnitTests
{
    [TestClass]
    public class NewsUnitTests
    {
        [TestMethod]
        public void TestEmail()
        {
            var model = new SignInModel { Email = "sdr@gmail.com", Password = "qwerty123" };
            SignInController signInController = new SignInController();
            var result = signInController.SignIn(model);
            Assert.IsNotNull(result);
        }
    }
}

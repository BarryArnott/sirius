namespace SiriusTests.Controllers
{
    using System.Web.Mvc;
    using NUnit.Framework;
    using SiriusApplication.Controllers;

    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void Test_WhenIndexIsCalled_ShouldReturn_ViewIndex()
        {
            // Setup
            var controller = new HomeController();

            // Exercise
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
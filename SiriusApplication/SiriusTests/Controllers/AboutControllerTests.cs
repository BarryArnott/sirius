namespace SiriusTests.Controllers
{
    using System.Web.Mvc;
    using NUnit.Framework;
    using SiriusApplication.Areas.About.Controllers;

    [TestFixture]
    public class AboutControllerTests
    {
        [Test]
        public void Test_WhenIndexIsCalled_ShouldReturn_ViewIndex()
        {
            // Setup
            var controller = new AboutController();

            // Exercise
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
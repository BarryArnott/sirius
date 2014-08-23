namespace SiriusTests.Controllers
{
    using System.Web.Mvc;
    using NUnit.Framework;
    using SiriusApplication.Areas.Technology.Controllers;

    [TestFixture]
    public class TechnologyControllerTests
    {
        [Test]
        public void Test_WhenIndexIsCalled_ShouldReturn_ViewIndex()
        {
            // Setup
            var controller = new TechnologyController();

            // Exercise
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}

namespace SiriusTests.Controllers
{
    using System.Web.Mvc;
    using NUnit.Framework;
    using SiriusApplication.Areas.Cycling.Controllers;

    [TestFixture]
    public class CyclingControllerTests
    {
        [Test]
        public void Test_WhenIndexIsCalled_ShouldReturn_ViewIndex()
        {
            // Setup
            var controller = new CyclingController();

            // Exercise
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}

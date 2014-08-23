namespace SiriusTests.Controllers
{
    using System.Web.Mvc;
    using NUnit.Framework;
    using SiriusApplication.Areas.Contact.Controllers;

    [TestFixture]
    public class ContactControllerTests
    {
        [Test]
        public void Test_WhenIndexIsCalled_ShouldReturn_ViewIndex()
        {
            // Setup
            var controller = new ContactController();

            // Exercise
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}

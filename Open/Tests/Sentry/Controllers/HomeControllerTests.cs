using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Sentry.Controllers;

namespace Open.Tests.Sentry.Controllers {
    [TestClass] public class HomeControllerTests : AcceptanceTests {

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(HomeController);
        }
        [TestMethod] public async Task IndexTest() {
            var a = GetUrl.ForControllerAction<HomeController>(x => x.Index());
            await testControllerAction(a, "<h1>Sentry</h1>",
                "<h2>Welcome to Sentry</h2>", "<h2>Download it</h2>");
        }
        [TestMethod] public async Task HomeTest() {
            var a = GetUrl.ForControllerAction<HomeController>();
            await testControllerAction(a, "<h1>Sentry</h1>", "<h2>Welcome to Sentry</h2>",
                "<h2>Download it</h2>");
        }
        [TestMethod] public async Task AboutTest() {
            var a = GetUrl.ForControllerAction<HomeController>(x => x.About());
            await testControllerAction(a, "<h2>About</h2>");
        }
        [TestMethod] public async Task ContactTest() {
            var a = GetUrl.ForControllerAction<HomeController>(x => x.Contact());
            await testControllerAction(a, "<h2>Contact</h2>");
        }
        [TestMethod] public async Task ErrorTest() {
            var a = GetUrl.ForControllerAction<HomeController>(x => x.Error());
            await testControllerAction(a, "<h1 class=\"text-danger\">Error.</h1>");
        }
    }
}





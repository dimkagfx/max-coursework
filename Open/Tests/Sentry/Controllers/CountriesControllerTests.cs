using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Location;
using Open.Sentry.Controllers;

namespace Open.Tests.Sentry.Controllers {

    [TestClass] public class CountriesControllerTests : AcceptanceTests {

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(CountriesController);
        }
        [TestMethod] public async Task IndexTest() {
            Assert.Inconclusive();
            var a = GetUrl.ForControllerAction<CountriesController>(x => x.Index(null, null, null, null));
            await testWhenLoggedOut(a, HttpStatusCode.Unauthorized);
            await testWhenLoggedIn(a, 
                "<h2>Countries</h2>",
                "<a asp-action=Create>Create New</a>", 
                "ISO Three Character Code",
                "ISO Two Character Code", 
                "Name", 
                "Valid From",
                "Valid To", 
                "<th></th>", 
                "<td>AFG</td>", 
                "<td>AF</td>",
                "<td>Afghanistan</td>",
                "<a href=\"/countries/Edit/AFG\">Edit</a>",
                "<a href=\"/countries/Details/AFG\">Details</a>",
                "<a href=\"/countries/Delete/AFG\">Delete</a>");
        }

        [TestMethod] public async Task CreateTest() {
            Assert.Inconclusive();
            var a = GetUrl.ForControllerAction<CountriesController>(x => x.Create());
            await testWhenLoggedOut(a, HttpStatusCode.Unauthorized);
            await testWhenLoggedIn(a, 
                "<h2>Create</h2>",
                "<form action=\"/countries/create\" method=\"post\">",
                "<h4>Country</h4>",
                "<input type=\"submit\" value=Create class=\"btn btn-default\" />",
                "<a href=\"/countries\">Back to List</a>"
                );
        }
        [TestMethod] public async Task CreateAllGivenTest() {
            Assert.Inconclusive();
            // http://www.stefanhendriks.com/2016/05/11/integration-testing-your-asp-net-core-app-dealing-with-anti-request-forgery-csrf-formdata-and-cookies/
            var c = GetRandom.Object<CountryViewModel>();
            c.Alpha3Code = "YYY";
            c.Alpha2Code = "YY";
            c.Name = "Some name";
            var d = new Dictionary<string, string>();
            var a = GetUrl.ForControllerAction<CountriesController>(x => x.Create());
            d.Add(GetMember.Name<CountryViewModel>(m => m.Alpha3Code), c.Alpha3Code);
            d.Add(GetMember.Name<CountryViewModel>(m => m.Alpha2Code), c.Alpha2Code);
            d.Add(GetMember.Name<CountryViewModel>(m => m.Name), c.Name);
            d.Add(GetMember.Name<CountryViewModel>(m => m.ValidFrom), c.ValidFrom.ToString());
            d.Add(GetMember.Name<CountryViewModel>(m => m.ValidTo), c.ValidTo.ToString());
            var content = new FormUrlEncodedContent(d);
            TestAuthenticationHandler.IsLoggedIn = true;
            var response = await client.PostAsync(a, content);
            Assert.AreEqual(HttpStatusCode.Redirect, response.StatusCode);
            var dbObject = await repository.GetObjectsList();
            Assert.IsNotNull(dbObject);
        }
        [TestMethod] public async Task CreateNoDatesTest() { Assert.Inconclusive(); }

        [TestMethod] public async Task CreateNoNameCodeOrIdTest() { Assert.Inconclusive(); }

        [TestMethod] public async Task CreateWhenIdAlreadyUseTest() { Assert.Inconclusive(); }

        [TestMethod] public async Task EditTest() {
            Assert.Inconclusive();
            var a = GetUrl.ForControllerAction<CountriesController>(x => x.Edit(""));
            a = a + "/AFG";
            await testWhenLoggedOut(a, HttpStatusCode.Unauthorized);
            await testWhenLoggedIn(a,
                "<h2>Edit</h2>",
                "type=\"hidden\" value=\"AFG\"",
                "value=\"AF\"",
                "value=\"Afghanistan\"",
                "<form action=\"/countries/edit/AFG\" method=\"post\">",
                "<h4>Country (AFG)</h4>",
                "<input type=\"submit\" value=Save class=\"btn btn-default\" />",
                "<a href=\"/countries\">Back to List</a>"
            );
        }

        [TestMethod] public async Task DetailsTest() {
            Assert.Inconclusive();
            var a = GetUrl.ForControllerAction<CountriesController>(x => x.Details(""));
            a = a + "/AFG";
            await testWhenLoggedOut(a, HttpStatusCode.Unauthorized);
            await testWhenLoggedIn(a,
                "<h2>Details</h2>",
                "AFG</div></div>",
                "AF</div></div>",
                "Afghanistan</div></div>",
                "<h4>Country</h4>",
                "<a href=\"/countries/Edit/AFG\">Edit</a>",
                "<a href=\"/countries\">Back to List</a>"
            );
        }

        [TestMethod] public async Task DeleteTest() {
            Assert.Inconclusive();
            var a = GetUrl.ForControllerAction<CountriesController>(x => x.Delete(""));
            a = a + "/AFG";
            await testWhenLoggedOut(a, HttpStatusCode.Unauthorized);
            await testWhenLoggedIn(a,
                "<h2>Delete</h2>",
                "AFG</div></div>",
                "AF</div></div>",
                "Afghanistan</div></div>",
                "<form action=\"/countries/delete/AFG\" method=\"post\">",
                "<h4>Country</h4>",
                "<input type=\"submit\" value=Delete class=\"btn btn-default\" />",
                "<a href=\"/countries\">Back to List</a>"
            );
        }

        [TestMethod] public async Task DeleteConfirmedTest() { Assert.Inconclusive(); }


        [TestMethod] public async Task EditNoDates() { Assert.Inconclusive(); }

        [TestMethod] public async Task EditNoNameCodeOrId() { Assert.Inconclusive(); }

        [TestMethod] public async Task BackToListFromCreate() { Assert.Inconclusive(); }

        [TestMethod] public async Task BackToListFromEdit() { Assert.Inconclusive(); }

        [TestMethod] public async Task BackToListFromDetails() { Assert.Inconclusive(); }

        [TestMethod] public async Task BackToListFromDelete() { Assert.Inconclusive(); }

        [TestMethod] public async Task ToEditFromDetails() { Assert.Inconclusive(); }

        [TestMethod] public void PropertiesTest() {
            const string c = ", ";
            var b = new StringBuilder();
            b.Append(GetMember.Name<CountryViewModel>(m => m.Alpha3Code));
            b.Append(c);
            b.Append(GetMember.Name<CountryViewModel>(m => m.Alpha2Code));
            b.Append(c);
            b.Append(GetMember.Name<CountryViewModel>(m => m.Name));
            b.Append(c);
            b.Append(GetMember.Name<CountryViewModel>(m => m.ValidFrom));
            b.Append(c);
            b.Append(GetMember.Name<CountryViewModel>(m => m.ValidTo));
            Assert.AreEqual(b.ToString(), CountriesController.properties);
        }

    }
}






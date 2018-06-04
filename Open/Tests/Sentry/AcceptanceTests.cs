using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.TestHost;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.Location;
using Open.Infra;
using Open.Infra.Location;
using Open.Sentry;

namespace Open.Tests.Sentry {
    public abstract class AcceptanceTests : BaseTests {
        protected Assembly assembly;
        protected HttpClient client;
        protected ICountryObjectsRepository repository;
        private bool useAuthentication;
        protected string path;
        private TestServer server;
        protected AcceptanceTests() {
            if (client != null) return;
            initializeTestServer();
        }
        protected async Task testWhenLoggedOut(string url, HttpStatusCode c) {
            var response = await client.GetAsync(url);
            Assert.AreEqual(c, response.StatusCode);
        }
        protected async Task testWhenLoggedIn(string url, params string[] content) {
            useAuthentication = true;
            await testControllerAction(url, content);
            useAuthentication = false;
        }
        protected async Task testControllerAction(string url, params string[] content) {
            TestAuthenticationHandler.IsLoggedIn = useAuthentication;
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            foreach (var c in content) { Assert.IsTrue(stringResponse.Contains(c), c); }
        }

        protected void initializeTestServer() {
            assembly = typeof(Startup).GetTypeInfo().Assembly;
            path = getPath();
            server = new TestServer(new WebHostBuilder().UseContentRoot(path)
                .UseStartup<TestStartup>()
                .ConfigureServices(services => configure(services, assembly)));
            initTestDatabase();
            client = server.CreateClient();
        }
        private void initTestDatabase() {
            using (var scope = server.Host.Services.CreateScope()) {
                var services = scope.ServiceProvider;
                repository = services.GetRequiredService<ICountryObjectsRepository>();
                var db = services.GetService<SentryDbContext>();
                CountriesDbTableInitializer.Initialize(db);
            }
        }
        private static void configure(IServiceCollection services, Assembly a) {
            services.Configure((RazorViewEngineOptions options) => {
                var previous = options.CompilationCallback;
                options.CompilationCallback = (context) => {
                    previous?.Invoke(context);
                    var assemblies = a.GetReferencedAssemblies().Select(x =>
                        MetadataReference.CreateFromFile(Assembly.Load(x).Location)).ToList();
                    addReference(assemblies, "netstandard");
                    addReference(assemblies, "System.Private.Corelib");
                    addReference(assemblies, "Microsoft.AspNetCore.Html.Abstractions");
                    addReference(assemblies, "System.Linq.Expressions");
                    addReference(assemblies, "Microsoft.CSharp");
                    context.Compilation = context.Compilation.AddReferences(assemblies);
                };
            });
        }
        private static void
            addReference(List<PortableExecutableReference> list, string assemblyName) {
            list.Add(MetadataReference.CreateFromFile(Assembly.Load(new AssemblyName(assemblyName))
                .Location));
        }
        private string getPath() {
            var n = "Open\\"+GetString.Tail(assembly.GetName().Name);
            var p = PlatformServices.Default.Application.ApplicationBasePath;
            var d = new DirectoryInfo(p);
            while (d != null) {
                var f = new FileInfo(Path.Combine(d.FullName, "Open.sln"));
                if (f.Exists) return Path.GetFullPath(Path.Combine(d.FullName, n));
                d = d.Parent;
            }

            throw new Exception($"No solution file in path <{p}>.");
        }
    }
}





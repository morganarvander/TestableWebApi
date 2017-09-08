using System.ComponentModel;
using System.Net.Http;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Owin;
using WebApi;

namespace TestableWebApi.Tests
{
    public abstract class WebApiUnitTest : UnitTest
    {
        private TestServer _server;
        protected HttpClient Client;
        protected Container Container;

        [TestCleanup]
        public void ShutdownServer()
        {
            _server.Dispose();
        }

        protected HttpClient CreateClient(Container container)
        {
            var httpConfiguration = new HttpConfiguration();

            _server = new TestServer(app =>
            {
                WebApiConfig.Register(httpConfiguration);
                app.UseWebApi(httpConfiguration);
            });

            var result = _server.HttpClient;

            return result;
        }

        protected abstract void SetupControllerDependencies(Container container);

        protected override void SetupDependencies()
        {
            SetupControllerDependencies(Container);
            Client = CreateClient(Container);
        }
    }
}
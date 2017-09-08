using System;
using System.Net.Http;
using Owin;

namespace TestableWebApi.Tests
{
    public class TestServer : Microsoft.Owin.Testing.TestServer
    {
        public TestServer(Action<IAppBuilder> configure)
        {
            Configure(configure);
        }

        public new HttpMessageHandler Handler => new Microsoft.Owin.Testing.OwinClientHandler(Invoke);

        public new HttpClient HttpClient => new HttpClient(Handler) { BaseAddress = BaseAddress };

    }
}
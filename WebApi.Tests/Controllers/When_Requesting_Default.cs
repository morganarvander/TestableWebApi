using System;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Shouldly;
using WebApi.Models;

namespace TestableWebApi.Tests.Controllers
{
    [TestClass]
    public class When_Requesting_Default : WebApiUnitTest
    {
        private HttpResponseMessage _response;
        private string _resultContent;
        private WebApiResult _resultObject;

        [TestMethod]
        public void Then_An_Instance_Of_WebApiResult_Should_Be_Returned()
        {
            _response.ShouldNotBeNull();
            _response.StatusCode.ShouldBe(HttpStatusCode.OK);
            _resultContent.ShouldNotBeNullOrEmpty();
            _resultObject.Name.ShouldBe("John Doe");
        }

        protected override void Act()
        {
            _response = this.Client.GetAsync("http://localhost/api/test").GetAwaiter().GetResult();
            _resultContent = _response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            _resultObject = JsonConvert.DeserializeObject<WebApiResult>(_resultContent);
        }

        protected override void SetupControllerDependencies(Container container)
        {
            
        }
    }
}
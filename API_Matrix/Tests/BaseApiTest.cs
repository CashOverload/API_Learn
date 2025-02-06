using API_Matrix.Data;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Matrix.Tests
{
    internal class BaseApiTest
    {
        protected RestClient client;

        [SetUp]
        public void Setup()
        {
            client = new RestClient(new RestClientOptions
            {
                BaseUrl = new Uri("https://reqres.in/api")
            });
        }

        [TearDown]
        public void TearDown()
        {
            client.Dispose();
        }

        protected RestRequest CreateRequest(string resource, Method method)
        {
            var request = new RestRequest(resource, method);
            request.AddHeader("Content-Type", "application/json");
            return request;
        }
        protected RestResponse SendRequest(RestRequest request)
        {
            return client.Execute(request);
        }

        protected T DeserializeResponse<T>(RestResponse response)
        {
            return DeserializeResponse<T>(response);
        }
        protected T GetRequestMethod<T>(RestRequest request)
        {
            return client.Get<T>(request);
        }
    }
}

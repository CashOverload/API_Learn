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
    internal class PostUserTest : BaseApiTest
    {
        [Test]
        public void PostUserCheck()
        {
            var request = CreateRequest("/users", Method.Post);

            request.AddJsonBody(new UserCreate
            {
                Name =  "TestName",
                Job = "TesJob"
            });

            var response = SendRequest(request);

            var user = JsonConvert.DeserializeObject<UserCreate>(response.Content);

            //var user = DeserializeResponse<UserCreate>(response);

            //Console.WriteLine(user.Id);
            //Console.WriteLine(user.Name);

            Assert.That((int)response.StatusCode == 201);
            //Assert.That(user.Name == "TestName");
            Console.WriteLine(response.Content);
            Console.WriteLine(user.Id);
        }

        [Test]
        public async Task PostUserCheckAsync()
        {
            var request = new RestRequest("/users");

            request.AddJsonBody(new UserCreate
            {
                Name = "TestName",
                Job = "TestJob"
            });

            var user = await client.PostAsync<UserCreate>(request);

            Assert.That(user.Name == "TestName");
            Assert.That(user.Job == "TestJob");
        }
    }
}

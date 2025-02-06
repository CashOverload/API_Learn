using API_Matrix.Data;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace API_Matrix.Tests
{
    internal class GetUsersTest : BaseApiTest
    {
        [Test]
        public void Test_GetUsers_Success()
        {
            var request = CreateRequest("/users/2", Method.Get);

            var response = SendRequest(request);
            //var user = DeserializeResponse<UserResponse>(response);
            var user = GetRequestMethod<UserResponse>(request);


            Assert.That(response.IsSuccessStatusCode, "Status code is not 200 OK");
            Assert.IsNotNull(response.Content, "Response content is null");
            Assert.IsTrue(response.Content.Contains("janet.weaver@reqres.in"), "Response does not contain user data");
            Console.WriteLine(user.Data.Email);
            Console.WriteLine(user.Data.Id);

        }

        [Test]
        public async Task Test_GetUsers_Success_Async()
        {
            var request = new RestRequest("/users/2");

            var user = await client.GetAsync<UserResponse>(request);


            Console.WriteLine(user?.Data?.Email);
            Console.WriteLine(user?.Data?.Id);

            Assert.That(user.Data.Email == "janet.weaver@reqres.in");
            Assert.That(user.Data.Id == 2);
        }
    }
}

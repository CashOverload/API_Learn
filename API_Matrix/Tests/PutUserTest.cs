using API_Matrix.Data;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Matrix.Tests
{
    internal class PutUserTest : BaseApiTest
    {
        [Test]
        public async Task PutAPIUserTest()
        {
            var request = CreateRequest("/users/2", Method.Put);
            request.AddJsonBody(new UserCreate
            {
                Name = "TestChange",
                Job = "TestJobChange"
            });

            var response = await client.PutAsync<UserCreate>(request);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Name == "TestChange");
            Assert.That(response.Job == "TestJobChange");
        }
    }
}

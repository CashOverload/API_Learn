using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Matrix.Tests
{
    internal class DeleteUser : BaseApiTest
    {
        [Test]
        public void DeleteAPIUser()
        {
            var request = CreateRequest("/users/2", Method.Delete);

            var response = SendRequest(request);

            Assert.That(response, Is.Not.Null);
            Assert.That((int)response.StatusCode == 204);
        }
    }
}

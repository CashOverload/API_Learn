using API_Matrix.RegisterModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Matrix.Tests
{
    internal class RegisterTests : BaseApiTest
    {
        [Test]
        public void RegisterUserTest()
        {
            var request = CreateRequest("/register", Method.Post);
            

            request.AddJsonBody(new RegisterRequest
            {
                Email = Consts.EMAIL,
                Password = Consts.PASSWORD
            });

            var response = SendRequest(request);

            var responseDeserialize = JsonConvert.DeserializeObject<RegisterResponse>(response.Content);

            Assert.That(response.IsSuccessStatusCode);
            Assert.That(responseDeserialize.Token != null);
            Assert.That(responseDeserialize.Id != null);

            Console.WriteLine(responseDeserialize.Token);
            Console.WriteLine(responseDeserialize.Id);
        }
    }
}

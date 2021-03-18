using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealLifeExample.Decorators
{
    public class RestClientLogDecorator : IRestClient
    {
        private readonly IRestClient _decoratedRestClient;

        public RestClientLogDecorator(IRestClient restClient)
        {
            _decoratedRestClient = restClient;
        }

        public IRestResponse Get(RestRequest request)
        {
            IRestResponse restResponse;
            restResponse = _decoratedRestClient.Get(request);

            Console.WriteLine($"LOG: call to {request.Resource}");

            return restResponse;
        }
    }
}

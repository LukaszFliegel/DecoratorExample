using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealLifeExample.Decorators
{
    public class RestClientRetryDecorator: IRestClient
    {
        private readonly IRestClient _decoratedRestClient;
        private readonly int _numberOfRetrys = 3;

        public RestClientRetryDecorator(IRestClient restClient)
        {
            _decoratedRestClient = restClient;
        }

        public IRestResponse Get(RestRequest request)
        {
            IRestResponse restResponse;
            var retryCount = _numberOfRetrys;
            do
            {                
                restResponse = _decoratedRestClient.Get(request);
                retryCount--;
                if (restResponse.StatusCode != System.Net.HttpStatusCode.OK && retryCount >= 0) Console.WriteLine($"Response {restResponse.StatusCode} Retrying...");
            }
            while (restResponse.StatusCode != System.Net.HttpStatusCode.OK && retryCount >= 0);

            return restResponse;
        }
    }
}

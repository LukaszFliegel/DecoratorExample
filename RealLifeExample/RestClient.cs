using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RealLifeExample
{
    public class RestClient : IRestClient
    {
        private RestSharp.RestClient _restClient;
        private RestSharp.RestClient _fakeRestClient;
        private readonly Random _random = new Random();
        public RestClient(string url)
        {
            _restClient = new RestSharp.RestClient(url);
            _fakeRestClient = new RestSharp.RestClient("http://fake.com/api");
        }

        public IRestResponse Get(RestRequest request)
        {
            Thread.Sleep(300);
            if (_random.Next(2) % 2 == 0)
            {
                return _fakeRestClient.Get(request);
            }
            else
            {
                return _restClient.Get(request);
            }
        }
    }
}

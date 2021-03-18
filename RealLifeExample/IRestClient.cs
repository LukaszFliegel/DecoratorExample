using RestSharp;

namespace RealLifeExample
{
    public interface IRestClient
    {
        IRestResponse Get(RestRequest request);
    }
}
using System.Net.Http.Headers;
using CoiviteEco.APP.Service.Annonce.Queries;
using CovoitEco.APP.Model.Models;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;

namespace CovoitEco.APP.Service.Annonce.Queries
{
    public class AnnonceQueriesService :  IAnnonceQueriesService
    {
        #region Fields

        private const int MaxRetries = 3;
        private static readonly Random Random = new Random();
        private readonly HttpClient _httpClient;
        private readonly AsyncRetryPolicy<AnnonceProfileVm> _retrypolicy;
        #endregion

        #region Constructor

        public AnnonceQueriesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _retrypolicy = Policy<AnnonceProfileVm>.Handle<HttpRequestException>().RetryAsync(MaxRetries);
        }


        #endregion

        public async Task<AnnonceProfileVm> GetAllAnnonceProfile(int id)
        {
            var httpResponse = "";

            return await _retrypolicy.ExecuteAsync(async () =>
            {
                if (Random.Next(1, 40) == 1)
                    throw new HttpRequestException("This is a fake request exception");
                var httpResponse = await _httpClient.GetAsync("https://localhost:7197/api/Annonce/GetAllAnnonceProfile?id=" + id);
                if (!httpResponse.IsSuccessStatusCode) throw new Exception();
                var content = await httpResponse.Content.ReadAsStringAsync();
                var annoncesProfile = JsonConvert.DeserializeObject<AnnonceProfileVm>(content);
                return annoncesProfile;
            });
        }
    }
}

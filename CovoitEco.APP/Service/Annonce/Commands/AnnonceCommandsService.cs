﻿using System.Net.Http.Headers;
using System.Net.Http.Json;
using CovoitEco.APP.Model.Models;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;

namespace CovoitEco.APP.Service.Annonce.Commands
{
    public class AnnonceCommandsService : IAnnonceCommandsService
    { 
        #region Fields

        private const int MaxRetries = 3;
        private static readonly Random Random = new Random();
        private readonly HttpClient _httpClient;
        private readonly AsyncRetryPolicy _retrypolicy;
        #endregion

        #region Constructor

        public AnnonceCommandsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _retrypolicy = Policy.Handle<HttpRequestException>().RetryAsync(MaxRetries);
        }


        #endregion


        public async Task CreateAnnonce(AnnonceProfileFormular formular)
        {
            await _retrypolicy.ExecuteAsync(async () =>
            {
                if (Random.Next(1, 40) == 1)
                    throw new HttpRequestException("This is a fake request exception");
                _httpClient.BaseAddress = new Uri("https://localhost:7197/api/Annonce/CreateAnnonce");
                var postCampingCar = await _httpClient.PostAsJsonAsync("Annonce/CreateAnnonce", formular);
                if (!postCampingCar.IsSuccessStatusCode)
                    throw new Exception();

            });
        }
    }
}

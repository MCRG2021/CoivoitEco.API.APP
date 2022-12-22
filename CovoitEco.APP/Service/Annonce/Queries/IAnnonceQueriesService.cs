using CovoitEco.APP.Model.Models;
using Microsoft.AspNetCore.Components;

namespace CoiviteEco.APP.Service.Annonce.Queries
{
    public interface IAnnonceQueriesService 
    {
        public Task<AnnonceProfileVm> GetAllAnnonceProfile(int id);
    }
}

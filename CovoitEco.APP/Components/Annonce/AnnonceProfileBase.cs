using CoiviteEco.APP.Service.Annonce.Queries;
using CovoitEco.APP.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;

namespace CovoitEco.APP.Components.Annonce
{
    /// <summary>
    /// test class
    /// </summary>
    public class AnnonceProfileBase : ComponentBase
    {
        public AnnonceProfileVm response { get; set; }
        public int id { get; set; }


        [Inject]
        public IAnnonceQueriesService AnnonceQueries { get; set; }



        protected async Task GetListAllAnnonceProfile()
        {
            response = await AnnonceQueries.GetAllAnnonceProfile(id);
        }
    }
}

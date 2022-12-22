using System.Reflection.Metadata;
using CoiviteEco.APP.Service.Annonce.Queries;
using CovoitEco.APP.Model.Models;
using CovoitEco.APP.Service.Annonce.Commands;
using Microsoft.AspNetCore.Components;

namespace CovoitEco.APP.Components.Annonce
{
    public class AnnonceComponent : ComponentBase
    {
        [Parameter]
        public AnnonceProfileVm response { get; set; }


        public AnnonceProfileFormular request { get; set; } = new AnnonceProfileFormular();

        [Parameter]
        public int id { get; set; }

        [Inject]
        public IAnnonceQueriesService AnnonceQueries { get; set; }

        [Inject]
        public IAnnonceCommandsService AnnonceCommands { get; set; }



        /// <summary>
        /// add get id user current
        /// </summary>
        /// <returns></returns>
        //[Authorize]
        protected override async Task OnInitializedAsync()
        {
            response = await AnnonceQueries.GetAllAnnonceProfile(1); // Id user current 
        }

        public void UpdateId(int id)
        {
            this.id = id;
        }

        protected async Task CreateAnnonceProfile()
        {
            await AnnonceCommands.CreateAnnonce(request);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovoitEco.Core.Application.Common.Interfaces;
using CovoitEco.Core.Application.Services.VehiculeProfile.Commands;
using MediatR;

namespace CovoitEco.Core.Application.Services.Reservation.Commands
{
    public class CreateReservationCommand : IRequest<int>
    {
        #region Properties

        public int RES_ANN_Id { get; set; }
        public int RES_UTL_Id { get; set; }

        #endregion
    }
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateReservationCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {

            var entity = new Domain.Entities.Reservation
            {
                RES_Id = 0, // auto increment 
                RES_DateReservation = DateTime.Now,
                RES_ANN_Id = request.RES_ANN_Id,
                RES_STATRES_Id = 1, // by default 
                RES_UTL_Id = request.RES_UTL_Id
            };

            _context.Reservation.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.RES_Id;

        }
    }
}

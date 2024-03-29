﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CovoitEco.Core.Application.Common.Interfaces;
using CovoitEco.Core.Application.DTOs;
using CovoitEco.Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CovoitEco.Core.Application.Services.VehiculeProfile.Queries
{
    public class GetVehiculeProfileQuery : IRequest<VehiculeProfileVm>
    {
        public int UTL_Id { get; set; }
    }
    public class GetVehiculeProfileQueryHandler : IRequestHandler<GetVehiculeProfileQuery, VehiculeProfileVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;


        public GetVehiculeProfileQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VehiculeProfileVm> Handle(GetVehiculeProfileQuery request, CancellationToken cancellationToken)
        {
         
            //    ).ProjectTo<VehiculeProfileDTO>(_mapper.ConfigurationProvider).OrderBy(x => x.VEHPR_Id).ToListAsync(cancellationToken)
            

            return new VehiculeProfileVm()
            {
                Lists = await (
                    from v in _context.Vehicule
                    where (v.VEH_Courant == true && v.VEH_UTL_Id == request.UTL_Id)
                    select new VehiculeProfileDTO()
                    {
                        VEHPR_Id = v.VEH_Id,
                        VEHPR_Immatriculation = v.VEH_Immatriculation,
                        VEHPR_Couleur = v.VEH_Couleur,
                        VEHPR_Marque = v.VEH_Marque,
                        VEHPR_Modele = v.VEH_Modele,
                        VEHPR_NombrePlace = v.VEH_NombrePlace,
                        VEHPR_NormeEuro = v.VEH_NormeEuro
                    }
                ).ToListAsync(cancellationToken)
            };

        }

    }
}

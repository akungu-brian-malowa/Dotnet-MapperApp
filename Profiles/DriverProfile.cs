using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MapperApp.models;
using MapperApp.models.DTOs.Incoming;
using MapperApp.models.DTOs.Outgoing;

namespace MapperApp.Profiles
{
    public class DriverProfile : Profile
    {
        public DriverProfile()
        {
            CreateMap<DriverForCreationDto, Driver>()
            .ForMember(
                destinationMember: dest => dest.Id,
                memberOptions: opt => opt.MapFrom(src => Guid.NewGuid())
            )
            .ForMember(
                destinationMember: dest => dest.FirstName,
                memberOptions: opt => opt.MapFrom(src => src.FirstName)
            )
            .ForMember(
                destinationMember: dest => dest.LastName,
                memberOptions: opt => opt.MapFrom(src => src.LastName)
            )
            .ForMember(
                destinationMember: dest => dest.DriverNumber,
                memberOptions: opt => opt.MapFrom(src => src.DriverNumber)
            )
            .ForMember(
                destinationMember: dest => dest.WorldChampionships,
                memberOptions: opt => opt.MapFrom(src => src.WorldChampionships)
            )
            .ForMember(
                destinationMember: dest => dest.Status,
                memberOptions: opt => opt.MapFrom(src => 1)
            )
            .ForMember(
                destinationMember: dest => dest.DateAdded,
                memberOptions: opt => opt.MapFrom(src => DateTime.Now)
            )
            .ForMember(
                destinationMember: dest => dest.DateUpdated,
                memberOptions: opt => opt.MapFrom(src => DateTime.Now)
            );
            CreateMap<Driver, DriversDto>()
            .ForMember(
               dest => dest.FullName,
               opt => opt.MapFrom(x => $"{x.FirstName} {x.LastName}")
            )
            .ForMember(
               dest => dest.Id,
               opt => opt.MapFrom(x => x.Id)
            )
            .ForMember(
               dest => dest.DriverNumber,
               opt => opt.MapFrom(x => x.DriverNumber)
            )
            .ForMember(
               dest => dest.WorldChampionships,
               opt => opt.MapFrom(x => x.WorldChampionships)
            )
            ;

        }

    }
}
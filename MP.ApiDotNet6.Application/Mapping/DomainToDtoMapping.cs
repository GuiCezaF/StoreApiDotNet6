using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MP.ApiDotNet6.Application.DTOS;
using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotNet6.Application.Mapping
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<Person, PersonDTO>();
        }
    }
}
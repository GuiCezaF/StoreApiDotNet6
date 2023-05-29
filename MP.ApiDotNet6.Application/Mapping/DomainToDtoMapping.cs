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
            CreateMap<Products, ProductDTO>();
            CreateMap<Purchase, PurchateDetailDTO>()
                .ForMember(x => x.Person, opt => opt.Ignore())
                .ForMember(x => x.Product, opt => opt.Ignore())
                .ConstructUsing((model, context) =>
                {
                    var dto = new PurchateDetailDTO
                    {
                        Product = model.Products.Name,
                        Id = model.Products.Id,
                        Date = model.Date,
                        Person = model.Person.Name,
                    };
                    return dto;
                });
        }
    }
}
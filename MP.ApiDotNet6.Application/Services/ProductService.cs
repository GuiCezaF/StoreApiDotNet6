using AutoMapper;
using MP.ApiDotNet6.Application.DTOS;
using MP.ApiDotNet6.Application.DTOS.Validations;
using MP.ApiDotNet6.Application.Services.Interfaces;
using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Domain.Repositories.Interfaces;

namespace MP.ApiDotNet6.Application.Services
{
  public class ProductService : IProductService
  {

    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
      _productRepository = productRepository;
      _mapper = mapper;
    }

    public async Task<ResultService<ProductDTO>> CreateAsync(ProductDTO productDTO)
    {
      if (productDTO == null)
      {
        return ResultService.Fail<ProductDTO>("Objeto deve ser informado");
      }

      var result = new ProductDTOValidator().Validate(productDTO);
      if (!result.IsValid)
      {
        return ResultService.RequestError<ProductDTO>("Problema na validação", result);
      }
      var product = _mapper.Map<Products>(productDTO);
      var data = await _productRepository.CreateAsync(product);
      return ResultService.Ok<ProductDTO>(_mapper.Map<ProductDTO>(data));
    }
  }
}
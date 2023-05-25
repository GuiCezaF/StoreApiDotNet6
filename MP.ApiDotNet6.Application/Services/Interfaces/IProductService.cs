using MP.ApiDotNet6.Application.DTOS;

namespace MP.ApiDotNet6.Application.Services.Interfaces
{
  public interface IProductService
    {
        Task<ResultService<ProductDTO>> CreateAsync(ProductDTO productDTO);
    }
}
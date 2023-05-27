using MP.ApiDotNet6.Application.DTOS;

namespace MP.ApiDotNet6.Application.Services.Interfaces
{
  public interface IPurchaseService
    {
    Task<ResultService<PurchaseDTO>> CreateAsync(PurchaseDTO purchaseDTO);
    }
}
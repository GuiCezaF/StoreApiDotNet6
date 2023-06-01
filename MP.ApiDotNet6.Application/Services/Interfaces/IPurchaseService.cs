using MP.ApiDotNet6.Application.DTOS;

namespace MP.ApiDotNet6.Application.Services.Interfaces
{
    public interface IPurchaseService
    {
        Task<ResultService<PurchaseDTO>> CreateAsync(PurchaseDTO purchaseDTO);

        Task<ResultService<PurchaseDetailDTO>> GetByIdAsync(int id);

        Task<ResultService<ICollection<PurchaseDetailDTO>>> GetAsync();

        Task<ResultService<PurchaseDTO>> UpdateAsync(PurchaseDTO purchaseDTO);

        Task<ResultService> RemoveAsync(int id);
    }
}
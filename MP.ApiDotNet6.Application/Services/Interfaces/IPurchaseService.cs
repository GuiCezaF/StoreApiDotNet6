using MP.ApiDotNet6.Application.DTOS;

namespace MP.ApiDotNet6.Application.Services.Interfaces
{
    public interface IPurchaseService
    {
        Task<ResultService<PurchaseDTO>> CreateAsync(PurchaseDTO purchaseDTO);

        Task<ResultService<PurchateDetailDTO>> GetByIdAsync(int id);

        Task<ResultService<ICollection<PurchateDetailDTO>>> GetAsync();
    }
}
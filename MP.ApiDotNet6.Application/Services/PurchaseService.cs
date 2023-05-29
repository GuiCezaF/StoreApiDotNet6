using AutoMapper;
using MP.ApiDotNet6.Application.DTOS;
using MP.ApiDotNet6.Application.DTOS.Validations;
using MP.ApiDotNet6.Application.Services.Interfaces;
using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Domain.Repositories.Interfaces;

namespace MP.ApiDotNet6.Application.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IProductRepository _productRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IMapper _mapper;

        public PurchaseService(IProductRepository productRepository, IPersonRepository personRepository, IPurchaseRepository purchaseRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _personRepository = personRepository;
            _purchaseRepository = purchaseRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<PurchaseDTO>> CreateAsync(PurchaseDTO purchaseDTO)
        {
            if (purchaseDTO == null)
            {
                return ResultService.Fail<PurchaseDTO>("Objeto deve ser informado");
            }

            var validate = new PurchaseDTOValidator().Validate(purchaseDTO);
            if (!validate.IsValid)
            {
                return ResultService.RequestError<PurchaseDTO>("Problemas de validação", validate);
            }

            var productId = await _productRepository.GetIdByCodErpAync(purchaseDTO.CodeErp);
            var personId = await _personRepository.GetIdByDocumentAsync(purchaseDTO.Document);
            var purchase = new Purchase(productId, personId);

            var data = await _purchaseRepository.CreateAsync(purchase);
            purchaseDTO.Id = data.Id;

            return ResultService.Ok<PurchaseDTO>(purchaseDTO);
        }

        public async Task<ResultService<ICollection<PurchateDetailDTO>>> GetAsync()
        {
            var purchases = await _purchaseRepository.GetAllAsync();
            return ResultService.Ok(_mapper.Map<ICollection<PurchateDetailDTO>>(purchases));
        }

        public async Task<ResultService<PurchateDetailDTO>> GetByIdAsync(int id)
        {
            var purchase = await _purchaseRepository.GetByIdAsync(id);
            if (purchase == null)
            {
                return ResultService.Fail<PurchateDetailDTO>("Compra não encontrada");
            }
            return ResultService.Ok(_mapper.Map<PurchateDetailDTO>(purchase));
        }
    }
}
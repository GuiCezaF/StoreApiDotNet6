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

        public async Task<ResultService<ICollection<ProductDTO>>> GetAsync()
        {
            var products = await _productRepository.GetProductsAsync();
            return ResultService.Ok<ICollection<ProductDTO>>(_mapper.Map<ICollection<ProductDTO>>(products));
        }

        public async Task<ResultService<ProductDTO>> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return ResultService.Fail<ProductDTO>("Produto não encontrado");
            }
            return ResultService.Ok<ProductDTO>(_mapper.Map<ProductDTO>(product));
        }

        public async Task<ResultService> RemoveAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return ResultService.Fail("Produto não encontrado");
            }
            await _productRepository.DeleteAsync(product);
            return ResultService.Ok($"Produto do id: {id} deletado com sucesso");
        }

        public async Task<ResultService> UpdateAsync(ProductDTO productDTO)
        {
            if (productDTO == null)
            {
                return ResultService.Fail("Objeto deve ser informado ");
            }

            var validation = new ProductDTOValidator().Validate(productDTO);
            if (!validation.IsValid)
            {
                return ResultService.RequestError("Problemas de validação", validation);
            }

            var product = await _productRepository.GetByIdAsync(productDTO.Id);
            if (product == null)
            {
                return ResultService.Fail("Produto não encontrado");
            }
            product = _mapper.Map<ProductDTO, Products>(productDTO, product);
            await _productRepository.EditAsync(product);
            return ResultService.Ok("Produto Editado com sucesso");
        }
    }
}
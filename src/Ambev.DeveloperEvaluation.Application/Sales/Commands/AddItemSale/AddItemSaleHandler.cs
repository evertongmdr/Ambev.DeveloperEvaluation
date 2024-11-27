using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.AddItemSale
{
    public class AddItemSaleHandler : IRequestHandler<AddItemSaleCommand, AddItemSaleResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleItemRepository _saleItemRepository;
        private readonly IMapper _mapper;

        public AddItemSaleHandler(IProductRepository productRepository, ISaleRepository saleRepository, 
            ISaleItemRepository saleItemRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _saleRepository = saleRepository;
            _saleItemRepository = saleItemRepository;
            _mapper = mapper;
        }

        public async Task<AddItemSaleResult> Handle(AddItemSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new AddItemSaleCommandValidator();

            var validationResult = validator.Validate(command);

            var  (sale, product) = await ValidateSaleAndProductExistenceAsync(command);

            var existsSaleItem = sale.ExistsSaleItem(product.Id);

            if (existsSaleItem == null)
            {
                var createdSaleItem = CreateSaleItem(sale, product, command.QuantityProduct);
                sale.AddSaleItem(createdSaleItem);

            } else
            {
                

            }

            return null;


        }

        private async Task<(Sale,Product)> ValidateSaleAndProductExistenceAsync(AddItemSaleCommand command)
        {
            var existsSale = await _saleRepository.GetWithSaleItemByIdAsync(command.SaleId);

            if (existsSale == null)
                throw new DomainException("The Sale was not found");

            var existsProduct = await _productRepository.GetByIdAsync(command.ProductId);

            if (existsProduct == null)
                throw new DomainException("The Product was not found");

            return (existsSale, existsProduct);
        }

        private SaleItem CreateSaleItem(Sale sale,Product product, int quantity)
        {
            return new SaleItem
            {
                SaleId = sale.Id,
                ProductId = product.Id,
                Quantity = quantity,
                UnitPrice = product.Price
            };
        }
    }
}

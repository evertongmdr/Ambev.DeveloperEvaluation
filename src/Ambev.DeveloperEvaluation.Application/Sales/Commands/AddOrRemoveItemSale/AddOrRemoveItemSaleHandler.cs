using Ambev.DeveloperEvaluation.Common.Messages.Commnad;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.AddItemSale
{
    public class AddOrRemoveItemSaleHandler : CommandHandler, IRequestHandler<AddOrRemoveItemSaleCommand, AddOrRemoveItemSaleResult?>
    {
        private readonly IProductRepository _productRepository;
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public AddOrRemoveItemSaleHandler(DomainValidationContext domainValidationContext,IProductRepository productRepository, 
            ISaleRepository saleRepository, IMapper mapper) : base(domainValidationContext)
        {
            _productRepository = productRepository;
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<AddOrRemoveItemSaleResult?> Handle(AddOrRemoveItemSaleCommand command, CancellationToken cancellationToken)
        {
            if (!ValidCommand(command)) return null;

            var (validationSuccess, sale, product) = await ValidateSaleAndProductExistenceAsync(command);

            if (!validationSuccess) return null;

           var existsMessageError =  sale.AddOrRemoveSaleItem(product.Id, product.Price, command.QuantityProduct);

            if (!string.IsNullOrEmpty(existsMessageError))
            {
                _domainValidationContext.AddValidationError("Add Item Sale", existsMessageError);
                return null;
            }

            var result = _mapper.Map<AddOrRemoveItemSaleResult>(sale);

            await _saleRepository.UpdateAsync(sale);

            return result;
        }

        private async Task<(bool sucess, Sale,Product)> ValidateSaleAndProductExistenceAsync(AddOrRemoveItemSaleCommand command)
        {
            var existsSale = await _saleRepository.GetWithSaleItemsByIdAsync(command.SaleId);

            if (existsSale == null)
            {
                _domainValidationContext.AddValidationError("Add Item Sale", "He ale was not found");
                return (false, null, null);
            }

            var existsProduct = await _productRepository.GetByIdAsync(command.ProductId);

            if (existsProduct == null)
            {
                _domainValidationContext.AddValidationError("Add Item Sale", "The Product was not found");
                return (false, null, null);
            }

            return (true, existsSale, existsProduct);
        }

    }
}

﻿using Ambev.DeveloperEvaluation.Application.Sales.Commands.CancelSale;
using Ambev.DeveloperEvaluation.Common.Messages;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.FinisheSale
{
    public class FinisheSaleCommand : Command<FinisheSaleResult>
    {
        public Guid SaleId { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new FinisheSaleCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
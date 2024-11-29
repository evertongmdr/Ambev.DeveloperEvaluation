﻿using Ambev.DeveloperEvaluation.Application.Sales.Commands.CancelSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSale
{
    public class CancelSaleProfile: Profile
    {
        public CancelSaleProfile()
        {
            CreateMap<CancelSaleRequest, CancelSaleCommand>();


        }
    }
}
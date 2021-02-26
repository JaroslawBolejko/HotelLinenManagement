﻿using HotelLinenManagement.ApplicationServices.API.Domain;
using HotelLinenManagement.DataAccess;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace HotelLinenManagement.ApplicationServices.API.Handlers
{
    class GetInvoicesHandler : IRequestHandler<GetAllInvoicesRequest, GetAllInvoicesResponse>
    {
        private readonly IRepository<Invoice> invoiceRepository;

        public GetInvoicesHandler(IRepository<DataAccess.Entities.Invoice> invoiceRepository)
        {
            this.invoiceRepository = invoiceRepository;
        }

        public Task<GetAllInvoicesResponse> Handle(GetAllInvoicesRequest request, CancellationToken cancellationToken)
        {
            var invoice = this.invoiceRepository.GetAll();
            var domainInvoices = invoice.Select(x => new Domain.Models.Invoice()
            {
                InvoiceNumber = x.InvoiceNumber,
                InviceDate = x.InviceDate,
                PaymentDate = x.PaymentDate,
                Description = x.Description,
                InvoiceTotal = x.InvoiceTotal

            });

            var response = new GetAllInvoicesResponse()
            {
                Data = domainInvoices.ToList()
            };
            return Task.FromResult(response);
        }
    }
}

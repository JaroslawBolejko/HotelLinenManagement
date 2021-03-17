using FluentValidation;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Invoices;
using System;

namespace HotelLinenManagement.ApplicationServices.API.Validators.Invoices
{
    public class PutInvoiceRequestValidator : AbstractValidator<PutInvoiceByIdRequest>
    {
        public PutInvoiceRequestValidator()
        {
            this.RuleFor(x => x.Id).NotNull().NotEmpty();
            this.RuleFor(x => x.LaundryId).NotNull().NotEmpty();
            this.RuleFor(x => x.HotelId).NotNull().NotEmpty();
            this.RuleFor(x => x.PaymentDate).NotNull().NotEmpty().GreaterThanOrEqualTo(DateTime.Now);
            this.RuleFor(x => x.DocumentDate).NotNull().NotEmpty().Equal(DateTime.Now);
            this.RuleFor(x => x.Description).NotNull().NotEmpty();
            this.RuleFor(x => x.InvoiceTotal).NotNull().NotEmpty();
            this.RuleFor(x => x.InvoiceTotal).NotNull().NotEmpty();
            this.RuleFor(x => x.DocumentName).NotNull().NotEmpty().MaximumLength(250);
            this.RuleFor(x => x.DocumentNumber).NotNull().NotEmpty();


        }
    }
}

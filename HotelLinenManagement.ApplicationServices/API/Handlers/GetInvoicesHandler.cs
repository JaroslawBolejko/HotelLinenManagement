using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses;
using HotelLinenManagement.DataAccess;
using HotelLinenManagement.DataAccess.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace HotelLinenManagement.ApplicationServices.API.Handlers
{
     public class GetInvoicesHandler : IRequestHandler<GetAllInvoicesRequest, GetAllInvoicesResponse>
    {
        private readonly IRepository<Invoice> invoiceRepository;
        private readonly IMapper mapper;

        public GetInvoicesHandler(IRepository<DataAccess.Entities.Invoice> invoiceRepository,IMapper mapper)
        {
            this.invoiceRepository = invoiceRepository;
            this.mapper = mapper;
        }

        public async Task<GetAllInvoicesResponse> Handle(GetAllInvoicesRequest request, CancellationToken cancellationToken)
        {
            var invoice = await this.invoiceRepository.GetAll();
            var mappedInvoice = this.mapper.Map<List<Domain.Models.Invoice>>(invoice);

            var response = new GetAllInvoicesResponse()
            {
                Data = mappedInvoice
            };
            return response;
        }
    }
}

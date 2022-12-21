using BookApi.Application.DTOs;
using BookApi.Domain.Entities;
using BookApi.Domain.Repositories;
using MediatR;

namespace BookApi.Application.Commands
{
    public class CreateCustomerCommand : IRequest<long>
    {
        public CustomerRequest customerRequest { get; set; }
    }

    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, long>
    {
        private readonly ICustomerRepository _repo;

        public CreateCustomerHandler(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public async Task<long> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer()
            {
                Address = request.customerRequest.Address,
                FirstName = request.customerRequest.FirstName,
                LastName = request.customerRequest.LastName,
            };

            var result = await _repo.Create(customer, cancellationToken);

            return result.Id;
        }
    }
}

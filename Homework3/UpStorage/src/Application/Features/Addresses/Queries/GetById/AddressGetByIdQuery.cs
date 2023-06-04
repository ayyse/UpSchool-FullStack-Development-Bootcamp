using Domain.Common;
using MediatR;

namespace Application.Features.Addresses.Queries.GetById
{
    public class AddressGetByIdQuery : IRequest<AddressGetByIdDto>
    {
        public Guid Id { get; set; }

        public AddressGetByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}

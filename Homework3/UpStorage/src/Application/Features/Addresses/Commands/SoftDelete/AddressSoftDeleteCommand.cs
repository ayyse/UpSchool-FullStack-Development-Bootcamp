using Domain.Common;
using MediatR;

namespace Application.Features.Addresses.Commands.SoftDelete
{
    public class AddressSoftDeleteCommand : IRequest<Response<int>>
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}

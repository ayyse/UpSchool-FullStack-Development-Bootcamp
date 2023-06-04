using Application.Common.Interfaces;
using Domain.Common;
using MediatR;

namespace Application.Features.Addresses.Commands.Delete
{
    public class AddressDeleteCommandHandler : IRequestHandler<AddressDeleteCommand, Response<int>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public AddressDeleteCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Response<int>> Handle(AddressDeleteCommand request, CancellationToken cancellationToken)
        {
            var address = _applicationDbContext.Addresses.FirstOrDefault(x => x.Id == request.Id);

            if (address is null)
                throw new InvalidOperationException("The address was not found");

            _applicationDbContext.Addresses.Remove(address);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return new Response<int>($"The address \"{address.Name}\" was successfully removed.");
        }
    }
}

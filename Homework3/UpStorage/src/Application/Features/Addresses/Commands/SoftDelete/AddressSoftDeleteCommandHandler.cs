using Application.Common.Interfaces;
using Domain.Common;
using MediatR;

namespace Application.Features.Addresses.Commands.SoftDelete
{
    public class AddressSoftDeleteCommandHandler : IRequestHandler<AddressSoftDeleteCommand, Response<int>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public AddressSoftDeleteCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Response<int>> Handle(AddressSoftDeleteCommand request, CancellationToken cancellationToken)
        {
            var address = _applicationDbContext.Addresses.FirstOrDefault(x => x.Id == request.Id);

            if (address is null)
                throw new InvalidOperationException("The address was not found");

            address.IsDeleted = true;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return new Response<int>($"The address \"{address.Name}\" was successfully soft deleted.");
        }
    }
}
